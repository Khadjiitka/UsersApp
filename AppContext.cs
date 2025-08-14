using System;
using System.Data.Entity; 

namespace UsersApp
{
	class AppContext : DbContext 
	{
	
		public AppContext() : base("DefaultConnection")
        {
            //Удаляет и пересоздаёт базу только если изменилась модель (например, добавили поле, удалили свойство и т. д.).
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());
        }

        public DbSet<User> Users { get; set; }// подключение к БД
    }

}

