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

        public static int DeleteGuest(int id)
        {
            GuestModel data = new GuestModel
            {
                NickName = "A",
                FancyMail = "B",
                FavouriteAnimal = "C",
                AnimalName = "D",
                Id = id
            };

            string sql = @"DELETE FROM dbo.PartyPeople WHERE ID = @id";
            return DataAccess.SaveData(sql, data);
        }
    }
}
