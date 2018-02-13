namespace MadBug.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bug_AddRowVersion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bugs", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bugs", "RowVersion");
        }
    }
}
