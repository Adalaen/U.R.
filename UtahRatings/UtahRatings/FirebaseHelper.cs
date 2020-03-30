using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace UtahRatings
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://utahratings.firebaseio.com/");

        public async Task<List<ListData>> GetAllLists()
        {
            return (await firebase
              .Child("Lists")
              .OnceAsync<ListData>()).Select(item => new ListData
              {
                  ListId = item.Object.ListId,
                  Name = item.Object.Name,
                  Description = item.Object.Description
              }).ToList();
        }
        public async Task AddList(int listId, string name, string description)
        {
            await firebase
              .Child("Lists")
              .PostAsync(new ListData() { 
                  ListId = listId, 
                  Name = name, 
                  Description = description 
              });
        }
        public async Task<ListData> GetList(int listId)
        {
            var allLists = await GetAllLists();
            await firebase
              .Child("Lists")
              .OnceAsync<ListData>();
            return allLists.Where(a => a.ListId == listId).FirstOrDefault();
        }
        public async Task UpdateList(int listId, string name, string description)
        {
            var toUpdateList = (await firebase
              .Child("Lists")
              .OnceAsync<ListData>()).Where(a => a.Object.ListId == listId).FirstOrDefault();

            await firebase
              .Child("Lists")
              .Child(toUpdateList.Key)
              .PutAsync(new ListData() {
                  ListId = listId,
                  Name = name,
                  Description = description
              });
        }
        public async Task DeleteList(int listId)
        {
            var toDeleteList = (await firebase
              .Child("Lists")
              .OnceAsync<ListData>()).Where(a => a.Object.ListId == listId).FirstOrDefault();
            await firebase.Child("Lists").Child(toDeleteList.Key).DeleteAsync();
        }
    }
}
