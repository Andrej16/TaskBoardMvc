namespace TaskBoardMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TfsNum = c.Int(nullable: false),
                        TfsName = c.String(),
                        UsedItems_Changed = c.String(),
                        UsedItems_New = c.String(),
                        TfsUrl = c.String(),
                        BackupId = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkItems");
        }
    }
}
