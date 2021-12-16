namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_skillcıkar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skills", "Name_Surname");
            DropColumn("dbo.Skills", "About");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "About", c => c.String(maxLength: 100));
            AddColumn("dbo.Skills", "Name_Surname", c => c.String(maxLength: 50));
        }
    }
}
