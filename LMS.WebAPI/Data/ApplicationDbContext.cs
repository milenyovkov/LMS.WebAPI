using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using LMS.WebAPI.Models;

namespace LMS.WebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<LawyersView> LawyersView { get; set; }
        public virtual DbSet<LeadingLawyersView> LeadingLawyersView { get; set; }
        public virtual DbSet<PartnersView> PartnersView { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Time> Times { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TypeClient> TypeClients { get; set; }
        public virtual DbSet<TypeProjectStatus> TypeProjectStatuses { get; set; }
        public virtual DbSet<TypeProject> TypeProjects { get; set; }
        public virtual DbSet<TypeTaskStatus> TypeTaskStatuses { get; set; }
        public virtual DbSet<TypeTaskPriority> TypeTaskPriorities { get; set; }
        public virtual DbSet<VatRate> VatRates { get; set; }
        public virtual DbSet<ClientsReport> ClientsReport { get; set; }
        public virtual DbSet<FeesReportByClient> FeesReportByClient { get; set; }
        public virtual DbSet<FeesReportByProject> FeesReportByProject { get; set; }
        public virtual DbSet<FeesReportByEmployee> FeesReportByEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Legal;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.ResourceIds).HasColumnName("ResourceIDs");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Appointments_fk_Employees");
            }); 

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.AddressCorrespondence).HasMaxLength(100);

                entity.Property(e => e.CompanyCase).HasMaxLength(100);

                entity.Property(e => e.ContactName).HasMaxLength(100);

                entity.Property(e => e.CountryId).HasMaxLength(3);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.IdNumber).HasMaxLength(13);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.ResponsibleName).HasMaxLength(100);

                entity.Property(e => e.VatId).HasMaxLength(15);

                entity.Property(e => e.Web).HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("Clients_fk_Countries");

                entity.HasOne(d => d.LeadingLawyer)
                    .WithMany(p => p.ClientLeadingLawyers)
                    .HasForeignKey(d => d.LeadingLawyerId)
                    .HasConstraintName("Clients_fk_Employees_LeadingLawyers");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.ClientPartners)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("Clients_fk_Employees_Partners");

                entity.HasOne(d => d.TypeClient)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.TypeClientId)
                    .HasConstraintName("Clients_fk_TypeClients");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(3);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasData(
                    new Country
                    {
                        Id = "100",
                        Name = "Bulgaria"
                    }
                );
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(3);

                entity.Property(e => e.Code).HasMaxLength(3);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasData(
                    new Currency
                    {
                        Id = "975",
                        Name = "Bulgarian lev",
                        Code = "BGN"
                    },
                    new Currency
                    {
                        Id = "978",
                        Name = "Euro",
                        Code = "EUR"
                    },
                    new Currency
                    {
                        Id = "840",
                        Name = "United States dollar",
                        Code = "USD"
                    },
                    new Currency
                    {
                        Id = "826",
                        Name = "Pound sterling",
                        Code = "GBP"
                    }
                );
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.AspNetUserId)
                    .HasMaxLength(450);

                entity.HasIndex(e => e.AspNetUserId).IsUnique().HasFilter(null);

                entity.Property(e => e.AspNetRoleId)
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(30);

                /*entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employees_fk_AspNetUsers");
                
                entity.HasOne(d => d.AspNetRole)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employees_fk_AspNetRoles");*/

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employees_fk_Positions");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Expenses_fk_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("Expenses_fk_Projects");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fees_fk_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("Fees_fk_Projects");
            });

            modelBuilder.Entity<LawyersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LawyersView");

                entity.Property(e => e.AspNetUserId)
                    .HasMaxLength(450);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<LeadingLawyersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LeadingLawyersView");

                entity.Property(e => e.AspNetUserId)
                    .HasMaxLength(450);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<PartnersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PartnersView");

                entity.Property(e => e.AspNetUserId)
                    .HasMaxLength(450);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Position>(entity =>
            {                
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasData(
                    new Position
                    {
                        Id = 1,
                        Name = "Partner"
                    },
                    new Position
                    {
                        Id = 2,
                        Name = "Senior Associate"
                    },
                    new Position
                    {
                        Id = 3,
                        Name = "Associate"
                    },
                    new Position
                    {
                        Id = 4,
                        Name = "Solicitor"
                    },
                    new Position
                    {
                        Id = 5,
                        Name = "Trainee"
                    }
                );
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Rate).HasColumnType("numeric(15, 4)");

                entity.Property(e => e.Reference).HasMaxLength(30);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.VatRate).HasColumnType("numeric(15, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Projecst_fk_Clients");

                entity.HasOne(d => d.LeadingLawyer)
                    .WithMany(p => p.ProjectLeadingLawyers)
                    .HasForeignKey(d => d.LeadingLawyerId)
                    .HasConstraintName("Projects_fk_Employees_LeadingLawyers");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.ProjectPartners)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("Projects_fk_Employees_Partners");

                entity.HasOne(d => d.TypeProject)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.TypeProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Project_fk_TypeProjects");

                entity.HasOne(d => d.TypeProjectStatus)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.TypeProjectStatusId)
                    .HasConstraintName("Project_fk_TypeProjectStatuses");

                entity.HasOne(d => d.VatRateNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.VatRate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Projects_fk_VatRates");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.ResourceName).HasMaxLength(50);
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Paid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TimeInMinutes).HasComputedColumnSql("([Hours]*(60)+[Minutes])");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Times)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Times_fk_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Times)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("Times_fk_Projects");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Subject).IsRequired().HasMaxLength(100);

                entity.Property(e => e.Description);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.TaskCompletion).HasColumnName("TaskCompletion");

                entity.Property(e => e.TaskReminder)
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaskReminderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("Tasks_fk_Projects");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TaskOwners)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("Tasks_fk_Employees_Owners");

                entity.HasOne(d => d.Assigned)
                    .WithMany(p => p.TaskAssigneds)
                    .HasForeignKey(d => d.AssignedId)
                    .HasConstraintName("Tasks_fk_Employees_Assigned");

                entity.HasOne(d => d.TaskStatus)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskStatusId)
                    .HasConstraintName("Tasks_fk_TypeTaskStatuses");

                entity.HasOne(d => d.TaskPriority)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskPriorityId)
                    .HasConstraintName("Tasks_fk_TypeTaskPriorities");

            });


            modelBuilder.Entity<TypeClient>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<TypeProjectStatus>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasData(
                    new TypeProjectStatus
                    {
                        Id = 1,
                        Name = "Active"
                    },
                    new TypeProjectStatus
                    {
                        Id = 2,
                        Name = "Completed"
                    }
                );
            });

            modelBuilder.Entity<TypeProject>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Reference).HasMaxLength(30);

                entity.HasData(
                    new TypeProject
                    {
                        Id = 1,
                        Name = "Due Diligence",
                        Reference = "DD"
                    },
                    new TypeProject
                    {
                        Id = 2,
                        Name = " General Legal Service",
                        Reference = "GLS"
                    },
                    new TypeProject
                    {
                        Id = 3,
                        Name = "Arbitration",
                        Reference = "A"
                    },
                    new TypeProject
                    {
                        Id = 4,
                        Name = "Civil litigation",
                        Reference = "CL"
                    },
                    new TypeProject
                    {
                        Id = 5,
                        Name = "Pre-litigation measures",
                        Reference = "PLM"
                    },
                    new TypeProject
                    {
                        Id = 6,
                        Name = "Administrative Case",
                        Reference = "AC"
                    },
                    new TypeProject
                    {
                        Id = 7,
                        Name = "Enforcement procedure",
                        Reference = "EP"
                    },
                    new TypeProject
                    {
                        Id = 8,
                        Name = "Obtaining Enforceable Court order",
                        Reference = "EOCO"
                    }
                );
            });

            modelBuilder.Entity<TypeTaskStatus>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasData(
                    new TypeTaskStatus
                    {
                        Id = 1,
                        Name = "Not Started"
                    },
                    new TypeTaskStatus
                    {
                        Id = 2,
                        Name = "In Progress"
                    },
                    new TypeTaskStatus
                    {
                        Id = 3,
                        Name = "Need Assistance"
                    },
                    new TypeTaskStatus
                    {
                        Id = 4,
                        Name = "Deffered"
                    },
                    new TypeTaskStatus
                    {
                        Id = 5,
                        Name = "Completed"
                    }
                );
            });

            modelBuilder.Entity<TypeTaskPriority>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasData(
                    new TypeTaskPriority
                    {
                        Id = 1,
                        Name = "Low"
                    },
                    new TypeTaskPriority
                    {
                        Id = 2,
                        Name = "Normal"
                    },
                    new TypeTaskPriority
                    {
                        Id = 3,
                        Name = "Urgent"
                    },
                    new TypeTaskPriority
                    {
                        Id = 4,
                        Name = "High"
                    }
                );
            });

            modelBuilder.Entity<VatRate>(entity =>
            {
                entity.HasKey(e => e.Rate);

                entity.Property(e => e.Rate).HasColumnType("decimal(15, 2)");

                entity.HasData(
                    new VatRate
                    {
                        Rate = 0
                    },
                    new VatRate
                    {
                        Rate = 20
                    }
                );
            });

            modelBuilder.Entity<ClientsReport>()
                .Property(p => p.TimeInHours)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<FeesReportByEmployee>()
                .Property(p => p.TimeInHours)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<FeesReportByClient>()
                .Property(p => p.TimeInHours)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<FeesReportByProject>()
                .Property(p => p.TimeInHours)
                .HasColumnType("decimal(15,2)");
        }
    }
}
