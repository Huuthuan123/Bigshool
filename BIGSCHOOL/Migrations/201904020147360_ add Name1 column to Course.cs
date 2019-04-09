namespace BIGSCHOOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addName1columntoCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Name1");
        }
    }
}
