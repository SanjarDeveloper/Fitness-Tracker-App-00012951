using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Tracker_App_00012951.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    Calories_burned = table.Column<double>(type: "float", nullable: false),
                    WorkoutTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Workouts_WorkoutTypes_WorkoutTypeID",
                        column: x => x.WorkoutTypeID,
                        principalTable: "WorkoutTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutTypeID",
                table: "Workouts",
                column: "WorkoutTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "WorkoutTypes");
        }
    }
}
