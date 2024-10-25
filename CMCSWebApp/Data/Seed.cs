using CMCSWebApp.Data.Enum;
using CMCSWebApp.Data;
using CMCSWebApp.Models;

public class Seed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateAsyncScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            SeedRoles(context);
            SeedProgrammes(context);
            SeedModules(context);
            SeedClaimForms(context);
            SeedClaims(context);
            SeedPastClaims(context);
        }
    }

    private static void SeedRoles(ApplicationDbContext context)
    {
        if (!context.Roles.Any())
        {
            var roles = new List<Roles>
            {
                new Roles { Name = "Lecturer" },
                new Roles { Name = "Academic Manager" },
                new Roles { Name = "Program Coordinator" }
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }

    private static void SeedProgrammes(ApplicationDbContext context)
    {
        if (!context.Programmes.Any())
        {
            var programmes = new List<Programme>
            {
                new Programme { Name = "DISD0601", Description = "Diploma in IT in Software Development" },
                new Programme { Name = "DINM0601", Description = "Diploma in IT in Network Management" },
                new Programme { Name = "DITM0601", Description = "Diploma in IT Management" }
            };

            context.Programmes.AddRange(programmes);
            context.SaveChanges();
        }
    }

    private static void SeedModules(ApplicationDbContext context)
    {
        if (!context.Modules.Any())
        {
            var modules = new List<Module>
            {
                new Module { Name = "PROG6212", Description = "DINM0601", ProgrammeID = 1 }, // Ensure ProgrammeID exists
                new Module { Name = "WEDE6021", Description = "DISD0601", ProgrammeID = 2 }  // Ensure ProgrammeID exists
            };

            context.Modules.AddRange(modules);
            context.SaveChanges();
        }
    }

    private static void SeedClaimForms(ApplicationDbContext context)
    {
        if (!context.ClaimForms.Any())
        {
            var claimForms = new List<ClaimForm>
            {
                new ClaimForm
                {
                    LecturerName = "Lindokuhle",
                    LecturerSurname = "Zwane",
                    EmployeeNumber = "L86-437-87",
                    ContactDetails = "(+27 23 456 7890)",
                    Programme = "Diploma in IT in Network Management",
                    Module = "PROG6212",
                    HoursWorked = 10,
                    HourlyRate = 15.00m,
                    SubmissionDate = DateOnly.FromDateTime(DateTime.Now),
                    SupportingDocs = new List<ItemsFeature>
                    {
                        new ItemsFeature { DocumentPath = "path/to/doc1.pdf" },
                        new ItemsFeature { DocumentPath = "path/to/doc2.pdf" }
                    }
                },
                new ClaimForm
                {
                    LecturerName = "Daluxolo",
                    LecturerSurname = "Zwide",
                    EmployeeNumber = "L86-437-89",
                    ContactDetails = "(+27 23 456-7890)",
                    Programme = "Diploma in IT in Software Development",
                    Module = "WEDE6021",
                    HoursWorked = 5,
                    HourlyRate = 20.00m,
                    SubmissionDate = DateOnly.FromDateTime(DateTime.Now),
                    SupportingDocs = new List<ItemsFeature>
                    {
                        new ItemsFeature { DocumentPath = "path/to/doc3.pdf" }
                    }
                }
            };

            context.ClaimForms.AddRange(claimForms);
            context.SaveChanges();
            // Now, create corresponding entries in the ReviewClaims table
            SeedReviewClaimsFromClaimForms(context, claimForms);
        }
    }

    private static void SeedClaims(ApplicationDbContext context)
    {
        if (!context.Claims.Any())
        {
            var previousClaims = new List<Claims>
            {
                new Claims
                {
                    EmployeeNo = "L86-437-87",
                    Programme = "DISD0601",
                    Module = "PROG6212/SAND6212",
                    HoursWorked = 8,
                    TotalAmount = 1180.00m,
                    SubmissionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-30)),
                    Status = ClaimStatus.Approved
                },
                new Claims
                {
                    EmployeeNo = "L86-437-88",
                    Programme = "DINM0601",
                    Module = "PROG6221",
                    HoursWorked = 4,
                    TotalAmount = 1140.00m,
                    SubmissionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-30)),
                    Status = ClaimStatus.Pending
                },
                new Claims
                {
                    EmployeeNo = "L86-437-89",
                    Programme = "DISD0601",
                    Module = "DATA6222/WEDE6021",
                    HoursWorked = 10,
                    TotalAmount = 1200.00m,
                    SubmissionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-30)),
                    Status = ClaimStatus.Approved
                },
                new Claims
                {
                    EmployeeNo = "L86-437-90",
                    Programme = "DITM0601",
                    Module = "SAND6211",
                    HoursWorked = 2,
                    TotalAmount = 1120.00m,
                    SubmissionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-30)),
                    Status = ClaimStatus.Declined
                }
            };

            context.Claims.AddRange(previousClaims);
            context.SaveChanges();

        }
    }

    private static void SeedReviewClaimsFromClaimForms(ApplicationDbContext context, List<ClaimForm> claimForms)
    {
        var reviewClaims = claimForms.Select(form => new ReviewClaims
        {
            ClaimID = form.ClaimID, // Assuming ClaimID is auto-generated after saving ClaimForms
            LecturerName = form.LecturerName,
            LecturerSurname = form.LecturerSurname,
            LecturerEmployeeNo = form.EmployeeNumber,
            Programme = form.Programme,
            Module = form.Module,
            ContactDetails = form.ContactDetails,
            HoursWorked = form.HoursWorked,
            HourlyRate = form.HourlyRate,
            SubmissionDate = form.SubmissionDate,
            SupportingDocs = string.Join(", ", form.SupportingDocs.Select(doc => doc.DocumentPath)) // Join document paths
        }).ToList();

        context.ReviewClaims.AddRange(reviewClaims);
        context.SaveChanges();
    }
    private static void SeedPastClaims(ApplicationDbContext context)
    {
        if (!context.SubmittedClaims.Any())
        {
            var submittedClaims = new List<SubmittedClaims>
        {
            new SubmittedClaims
            {
                EmployeeNo = "L86-437-87",
                Programme = "DISD0601",
                Module = "PROG6212",
                Hours = 8,
                Total = 1180.00m,
                Date = new DateTime(2024, 10, 9),
                Status = ClaimStatus.Approved,
            },
            new SubmittedClaims
            {
                EmployeeNo = "L86-437-87",
                Programme = "DINM0601",
                Module = "PROG6221/DATA6222",
                Hours = 12,
                Total = 2120.00m,
                Date = new DateTime(2024, 9, 9),
                Status = ClaimStatus.Approved
            },
            new SubmittedClaims
            {
                EmployeeNo = "L86-437-87",
                Programme = "DITM0601",
                Module = "PROG6222",
                Hours = 10,
                Total = 1500.00m,
                Date = new DateTime(2024, 10, 8),
                Status = ClaimStatus.Declined
            }
        };

            context.SubmittedClaims.AddRange(submittedClaims);
            context.SaveChanges();
        }
    }

}