using HealthClaim.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL
{
    public class HealthClaimDbContext : IdentityDbContext<ApplicationUser>
    {
        public HealthClaimDbContext(DbContextOptions<HealthClaimDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<AdvanceStatusCategory> AdvanceStatusCategorys { get; set; }
        public DbSet<AdvanceUploadDocument> AdvanceUploadDocuments { get; set; }
        public DbSet<AdvanceUploadTypeDetail> AdvanceUploadTypeDetails { get; set; }
        public DbSet<EmpAccountDetail> EmpAccountDetails { get; set; }
        public DbSet<EmpAdvance> EmpAdvances { get; set; }
        public DbSet<EmpAdvanceStatus> EmpAdvanceStatus { get; set; }
        public DbSet<EmpFamily> EmpFamilys { get; set; }
        public DbSet<EmpFamilyITR> EmpFamilyITRs { get; set; }
        public DbSet<EmpFamilyPAN> EmpFamilyPANs { get; set; }
        public DbSet<EmpRelation> EmpRelations { get; set; }
        public DbSet<HospitalAccountDetail> HospitalAccountDetails { get; set; }
        public DbSet<UplodDocType> UplodDocType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.Employee).WithMany()
                .HasForeignKey(e => e.EmplId)
                .OnDelete(DeleteBehavior.ClientSetNull); // Set the desired behavior

            modelBuilder.Entity<Employee>().HasOne(e => e.EmployeeCreatedBy).WithMany()
               .HasForeignKey(e => e.CreatedBy)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Employee>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull); // Set the desired behavior
           
            modelBuilder.Entity<AdvanceStatusCategory>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAccountDetail>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAccountDetail>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull); 
            
           
            modelBuilder.Entity<EmpRelation>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull); 

           
            modelBuilder.Entity<HospitalAccountDetail>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull); 

           
            modelBuilder.Entity<UplodDocType>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull); 
            
           
            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<EmpRelation>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpFamily>().HasOne(e => e.EmpRelation).WithMany()
                .HasForeignKey(e => e.RelationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpFamily>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpFamily>().HasOne(e => e.Employee).WithMany()
                .HasForeignKey(e => e.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.Employee).WithMany()
                .HasForeignKey(e => e.EmplId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeApproveBy).WithMany()
                .HasForeignKey(e => e.ApprovedById)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpAdvance>().HasOne(e => e.EmployeeRequestSubmited).WithMany()
                .HasForeignKey(e => e.RequestSubmittedById)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpFamilyITR>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpFamilyITR>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpFamilyPAN>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpFamilyPAN>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<AdvanceUploadTypeDetail>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<AdvanceUploadTypeDetail>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<AdvanceUploadTypeDetail>().HasOne(e => e.UplodDocType).WithMany()
                .HasForeignKey(e => e.UploadTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpAdvanceStatus>().HasOne(e => e.EmpAdvance).WithMany()
                .HasForeignKey(e => e.AdvanceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EmpAdvanceStatus>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<EmpAdvanceStatus>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<AdvanceUploadDocument>().HasOne(e => e.EmployeeCreatedBy).WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<AdvanceUploadDocument>().HasOne(e => e.EmployeeUpdatedBy).WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
