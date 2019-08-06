using System;
using System.Collections.Generic;
using System.Text;

namespace PartyLibrary2
{
    public class GuestProcessor
    {
        public static int CreateGuest(string nickName, string fancyMail, string favouriteAnimal, 
                bool? willAttend)
        {
            GuestModel data = new GuestModel
            {
                NickName = nickName,
                FancyMail = fancyMail,
                FavouriteAnimal = favouriteAnimal,
                AnimalName = nickName[0] + " the wild " + favouriteAnimal
            };

            string sql = @"INSERT INTO dbo.PartyPeople (NickName, FancyMail, FavouriteAnimal, AnimalName)
                            VALUES (@NickName, @FancyMail, @FavouriteAnimal, @AnimalName);";

            return DataAccess.SaveData(sql, data);
        }
    }
}
