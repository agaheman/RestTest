using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestTest.Infra.Data.Sql.Command.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<long>(type: "bigint", fixedLength: true, maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "NationalCode" },
                values: new object[] { 1, "TaherSamadi@gmail.com", "Taher", "Samadi", 2660039991L });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "NationalCode" },
                values: new object[] { 2, "AmirHosseinLesani@gmail.com", "AmirHossein", "Lesani", 2660039993L });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "NationalCode" },
                values: new object[] { 3, "NimaKhandabi@gmail.com", "Nima", "Khandabi", 2660039995L });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "Content", "EmployeeId", "Name", "Published" },
                values: new object[] { 1, "Chekhof1", 1, "Montakhab1", true });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "Content", "EmployeeId", "Name" },
                values: new object[] { 2, "Chekhof2", 1, "Dibache2" });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "Content", "EmployeeId", "Name", "Published" },
                values: new object[,]
                {
                    { 3, "Veronic1", 2, "Montakhab3", true },
                    { 4, "Veronic2", 2, "Dibache4", true },
                    { 5, "LastState1", 3, "Montakhab5", true },
                    { 6, "LastState2", 3, "Dibache6", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_EmployeeId",
                table: "Note",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
