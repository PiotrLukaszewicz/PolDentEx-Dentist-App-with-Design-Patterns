namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsChildField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "IsChild", c => c.Boolean(nullable: false));

        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "IsChild");
        }
    }
}
