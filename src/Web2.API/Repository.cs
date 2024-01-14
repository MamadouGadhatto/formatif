using Microsoft.AspNetCore.Mvc;

namespace Web2.API
{
    public static class Repository
    {
        private static List<User> users = new List<User>();

        private static List<Annonce> annonces = new List<Annonce>();

        public static  List<User> GetUsers()
        {
            
            return (users);
        }
        public static List<Annonce> GetAnnonces()
        {
            return (annonces);
        }

        public static void CreateUser(User user)
        {
            users.Add(user);
        }
        public static void CreateAnnonce(Annonce annonce)
        {
            annonces.Add(annonce);
        }
    }
}
