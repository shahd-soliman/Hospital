using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using WebApplication3.Models;

namespace P.Models;

public partial class HospitalContext : IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
{
    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Nurse> Nurses { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<Appointment> Appointments { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=DESKTOP-H25VUCM\\SQLEXPRESS;Database=HopeHospital;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        modelBuilder.Entity<IdentityUserRole<int>>().HasKey(r => new { r.UserId, r.RoleId });
        modelBuilder.Entity<IdentityUserToken<int>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId);

            entity.ToTable("Department");

            entity.Property(e => e.DeptId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Dept_ID");
            entity.Property(e => e.DeptLocation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Dept_Location");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dept_Name");
        });

        
        modelBuilder.Entity<Doctor>(entity =>
        {
        entity.HasKey(d => d.DId);

        entity.Property(d => d.DId).ValueGeneratedOnAdd();  
    
            entity.ToTable("Doctor");

            entity.Property(e => e.DeptId).HasColumnName("Dept_ID");

            entity.HasOne(d => d.Dept).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ddo_id");

        });

       
        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId);

            entity.ToTable("MedicalRecord");

            entity.Property(e => e.Did).HasColumnName("DId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.MedicalRecords).HasForeignKey(d => d.Did);
        });

      

        modelBuilder.Entity<Nurse>(entity =>
        {
            entity.HasKey(e => e.NId).HasName("PK__Nurse__71CC86203764848A");

            entity.ToTable("Nurse");

            entity.Property(e => e.NId)
                .ValueGeneratedOnAdd()
                .HasColumnName("N_ID");
            entity.Property(e => e.EmpId).HasColumnName("Emp_ID");
            entity.Property(e => e.TypeDegree)
                .HasMaxLength(50)
                .HasColumnName("Type_Degree");
        });

      

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PId);  // Sets PId as the primary key

            entity.Property(e => e.PId)  // Configures the PId property
                .ValueGeneratedOnAdd()   // Specifies that the PId is auto-generated (typically as an auto-incrementing field)
                .HasColumnName("P_ID");  // Maps the PId property to the "P_ID" column in the database

            entity.ToTable("Patient");  // Maps the entity to the "Patient" table in the database


            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.F_Name)
                .HasMaxLength(50)
                .HasColumnName("F_Name");
            entity.Property(e => e.L_Name)
                .HasMaxLength(50)
                .HasColumnName("L_Name");
            entity.Property(e => e.NId).HasColumnName("N_ID");
            entity.Property(e => e.RoomId).HasColumnName("Room_ID");

            entity.HasOne(d => d.Nurse).WithMany(p => p.Patients)
                .HasForeignKey(d => d.NId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_Nurse");

            entity.HasOne(d => d.Record).WithMany(p => p.Patients).HasForeignKey(d => d.RecordId);

            entity.HasOne(d => d.Room).WithMany(p => p.Patients)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_Room");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).IsClustered(false);

            entity.ToTable("Room");

            entity.HasIndex(e => e.RoomId, "Room_ID").IsClustered();

            entity.Property(e => e.RoomId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Room_ID");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RoomName)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Room_Name");
        });

     
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
//Scaffold-DbContext "Server=DESKTOP-H25VUCM\SQLEXPRESS;Database=Hospital;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
//to add model of existed database 
//-force for medical record part can be removed
//Enable-Migrations
//EntityFrameworkCore\Add-Migration InitialCreate
//EntityFrameworkCore\Update-Database
//Newtonsoft.Json install library for paypal