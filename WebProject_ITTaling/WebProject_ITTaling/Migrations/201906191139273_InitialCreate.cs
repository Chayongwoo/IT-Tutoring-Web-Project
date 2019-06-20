namespace WebProject_ITTaling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        applicationID = c.Int(nullable: false, identity: true),
                        applicationLevel = c.String(),
                        lectureID = c.Int(nullable: false),
                        memberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.applicationID)
                .ForeignKey("dbo.Lecture", t => t.lectureID, cascadeDelete: true)
                .Index(t => t.lectureID);
            
            CreateTable(
                "dbo.ApplySchedule",
                c => new
                    {
                        applyScheduleID = c.Int(nullable: false, identity: true),
                        applyDayofweek = c.String(),
                        applyScheduleTime = c.String(),
                        applicationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.applyScheduleID)
                .ForeignKey("dbo.Application", t => t.applicationID, cascadeDelete: true)
                .Index(t => t.applicationID);
            
            CreateTable(
                "dbo.Lecture",
                c => new
                    {
                        lectureID = c.Int(nullable: false, identity: true),
                        lectureTitle = c.String(),
                        lectureLanguage = c.String(),
                        lectureImage = c.String(),
                        tutorIntroduce = c.String(),
                        lectureIntroduce = c.String(),
                        lecturePeople = c.String(),
                        lecturePlan = c.String(),
                        lectureCount = c.Int(nullable: false),
                        lecturePrice = c.Int(nullable: false),
                        lectureMaxperson = c.Int(nullable: false),
                        lectureApplyDeadline = c.DateTime(nullable: false),
                        lectureLocation = c.String(),
                        lecturePlace = c.String(),
                        memberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lectureID)
                .ForeignKey("dbo.Member", t => t.memberID, cascadeDelete: true)
                .Index(t => t.memberID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        memberID = c.Int(nullable: false, identity: true),
                        memberName = c.String(),
                        memberEmail = c.String(),
                        memberPassword = c.String(),
                        memberType = c.String(),
                        memberPhone = c.String(),
                        tutorImage = c.String(),
                        tutorPortfolio = c.String(),
                        tutorGit = c.String(),
                    })
                .PrimaryKey(t => t.memberID);
            
            CreateTable(
                "dbo.License",
                c => new
                    {
                        licenseID = c.Int(nullable: false, identity: true),
                        licenseName = c.String(),
                        licenseNumber = c.String(),
                        licenseAgency = c.String(),
                        licenseAcqDate = c.DateTime(nullable: false),
                        memberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.licenseID)
                .ForeignKey("dbo.Member", t => t.memberID, cascadeDelete: true)
                .Index(t => t.memberID);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        reviewID = c.Int(nullable: false, identity: true),
                        reviewContent = c.String(),
                        reviewGrade = c.Int(nullable: false),
                        lectureID = c.Int(nullable: false),
                        memberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.reviewID)
                .ForeignKey("dbo.Lecture", t => t.lectureID, cascadeDelete: true)
                .Index(t => t.lectureID);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        scheduleID = c.Int(nullable: false, identity: true),
                        dayofweek = c.String(),
                        scheduleTime = c.String(),
                        lectureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.scheduleID)
                .ForeignKey("dbo.Lecture", t => t.lectureID, cascadeDelete: true)
                .Index(t => t.lectureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "lectureID", "dbo.Lecture");
            DropForeignKey("dbo.Review", "lectureID", "dbo.Lecture");
            DropForeignKey("dbo.License", "memberID", "dbo.Member");
            DropForeignKey("dbo.Lecture", "memberID", "dbo.Member");
            DropForeignKey("dbo.Application", "lectureID", "dbo.Lecture");
            DropForeignKey("dbo.ApplySchedule", "applicationID", "dbo.Application");
            DropIndex("dbo.Schedule", new[] { "lectureID" });
            DropIndex("dbo.Review", new[] { "lectureID" });
            DropIndex("dbo.License", new[] { "memberID" });
            DropIndex("dbo.Lecture", new[] { "memberID" });
            DropIndex("dbo.ApplySchedule", new[] { "applicationID" });
            DropIndex("dbo.Application", new[] { "lectureID" });
            DropTable("dbo.Schedule");
            DropTable("dbo.Review");
            DropTable("dbo.License");
            DropTable("dbo.Member");
            DropTable("dbo.Lecture");
            DropTable("dbo.ApplySchedule");
            DropTable("dbo.Application");
        }
    }
}
