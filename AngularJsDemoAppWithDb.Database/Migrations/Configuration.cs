using AngularJsDemoAppWithDb.Database.Entities;

namespace AngularJsDemoAppWithDb.Database.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.DemoAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.DemoAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Person.Add(new PersonEntity()
            {
                Age = 20,
                Name = "Fabian"
            });

            context.Person.Add(new PersonEntity()
            {

                Age = 30,
                Name = "John"
            });

            context.SaveChanges();
        }
    }
}
