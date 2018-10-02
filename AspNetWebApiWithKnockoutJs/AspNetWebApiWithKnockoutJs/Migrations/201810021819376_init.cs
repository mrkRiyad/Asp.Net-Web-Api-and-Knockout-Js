namespace AspNetWebApiWithKnockoutJs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        ProfileImageUrl = c.String(),
                        fkCourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Courses", t => t.fkCourseID, cascadeDelete: true)
                .Index(t => t.fkCourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "fkCourseID", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "fkCourseID" });
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
