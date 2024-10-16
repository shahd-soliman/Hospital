using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Dept_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Dept_Location = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Web_Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Dept_ID);
                });

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    N_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Degree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Emp_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nurse__71CC86203764848A", x => x.N_ID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Room_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Name = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Location = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    RoomImg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Room_ID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: true),
                    Hire_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shift_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dept_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DId);
                    table.ForeignKey(
                        name: "fk_ddo_id",
                        column: x => x.Dept_ID,
                        principalTable: "Department",
                        principalColumn: "Dept_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestResults = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgressNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentPlans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VitalSigns = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurgicalReports = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DischargeSummaries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_Doctor_DId",
                        column: x => x.DId,
                        principalTable: "Doctor",
                        principalColumn: "DId");
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    L_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    N_ID = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<int>(type: "int", nullable: true),
                    Room_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.P_ID);
                    table.ForeignKey(
                        name: "FK_Patient_MedicalRecord_RecordId",
                        column: x => x.RecordId,
                        principalTable: "MedicalRecord",
                        principalColumn: "RecordId");
                    table.ForeignKey(
                        name: "FK_Patient_Nurse",
                        column: x => x.N_ID,
                        principalTable: "Nurse",
                        principalColumn: "N_ID");
                    table.ForeignKey(
                        name: "FK_Patient_Room",
                        column: x => x.Room_ID,
                        principalTable: "Room",
                        principalColumn: "Room_ID");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    DocId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Department",
                        principalColumn: "Dept_ID");
                    table.ForeignKey(
                        name: "FK_Appointments_Doctor_DocId",
                        column: x => x.DocId,
                        principalTable: "Doctor",
                        principalColumn: "DId");
                    table.ForeignKey(
                        name: "FK_Appointments_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "P_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DeptId",
                table: "Appointments",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DocId",
                table: "Appointments",
                column: "DocId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Dept_ID",
                table: "Doctor",
                column: "Dept_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_DId",
                table: "MedicalRecord",
                column: "DId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_N_ID",
                table: "Patient",
                column: "N_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_RecordId",
                table: "Patient",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Room_ID",
                table: "Patient",
                column: "Room_ID");

            migrationBuilder.CreateIndex(
                name: "Room_ID",
                table: "Room",
                column: "Room_ID")
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "Nurse");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
