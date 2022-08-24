using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class NewInboxView
    {
        private readonly string BASE_URL = "https://candidate.hubteam.com/candidateTest/v3/problem";
        private readonly string API_KEY = "1c8ddcc2bc6daadb231798518f7f";
        private readonly string QUERY;
        private readonly HttpClient _client;

        public NewInboxView()
        {
            _client = new HttpClient();
            InitClient();

            QUERY = "{0}/{1}?userKey={2}";
        }

        public async void SolveProblem()
        {
            Dataset dsData = await RequestDataset();
            if(dsData != null)
            {
                List<Conversation> conversations = Convert(dsData);
                Result result = new Result();
                result.conversations = conversations;
                await SubmitInboxView(result);
            }
        }


        private void InitClient()
        {
            _client.BaseAddress = new Uri(BASE_URL);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private List<Conversation> Convert(Dataset ds)
        {
            int myUserId = ds.userId;
            //user id / user class
            Dictionary<int, User> seenUser = new Dictionary<int, User>();
            foreach(var user in ds.users)
            {
                if(user.id != myUserId && seenUser.ContainsKey(user.id) == false)
                    seenUser.Add(user.id, user);
            }
            //user id / # of message
            Dictionary<int, int> cntMsgByUserId = new Dictionary<int, int>();
            foreach(var msg in ds.messages)
            {
                int userId = msg.fromUserId;    ////I am a recipient.
                if (msg.fromUserId == myUserId)
                {
                    //I am a sender.
                    userId = msg.toUserId;
                    if (userId == myUserId)
                        continue;
                }
                if (cntMsgByUserId.ContainsKey(userId) == false)
                    cntMsgByUserId.Add(userId, 0);
                cntMsgByUserId[userId]++;
            }

            //check messages 
            List<Conversation> conversations = new List<Conversation>();
            //Sort messages 
            var sortedMsgDesc = from msg in ds.messages
                                orderby msg.timestamp descending
                                select msg;

            foreach(var msg in sortedMsgDesc)
            {
                int userId = msg.fromUserId;    ////I am a recipient.
                if ( msg.fromUserId == myUserId)
                {
                    //I am a sender.
                    userId = msg.toUserId;
                }
                
                //check if this user has been already added in a list of conversations
                if( seenUser.ContainsKey(userId))
                {
                    Conversation cv = new Conversation();
                    cv.userId = userId;
                    cv.avatar = seenUser[userId].avatar;
                    cv.firstName = seenUser[userId].firstName;
                    cv.lastName = seenUser[userId].lastName;
                    cv.totalMessages = cntMsgByUserId[userId];
                    MostRecentMessage mostMsg = new MostRecentMessage();
                    mostMsg.content = msg.content;
                    mostMsg.timestamp = msg.timestamp;
                    mostMsg.userId = msg.fromUserId;
                    cv.mostRecentMessage = mostMsg;
                    conversations.Add(cv);

                    seenUser.Remove(userId);
                }
            }

            return conversations;
        }
        /// <summary>
        /// request to the dataset API
        /// </summary>
        /// <returns></returns>
        private async Task<Dataset> RequestDataset()
        {
            Dataset ds = null;
            InitClient();
            HttpResponseMessage response = await _client.GetAsync(String.Format(QUERY, BASE_URL, "dataset", API_KEY));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ds = JsonSerializer.Deserialize<Dataset>(content);
            }
            //ds = JsonSerializer.Deserialize<Dataset>("{    \"messages\": [        {            \"content\": \"The quick brown fox jumps over the lazy dog\",            \"fromUserId\": 50210,            \"timestamp\": 1529338342000,            \"toUserId\": 67452        },        {            \"content\": \"Pangrams originate in the discotheque\",            \"fromUserId\": 67452,            \"timestamp\": 1529075415000,            \"toUserId\": 50210        },        {            \"content\": \"Have you planned your holidays this year yet?\",            \"fromUserId\": 67452,            \"timestamp\": 1529542953000,            \"toUserId\": 50210       },       {            \"content\": \"Strange noises have been heard on the moors\",            \"fromUserId\": 78596,            \"timestamp\": 1533112961000,            \"toUserId\": 50210       },       {           \"content\": \"You go straight ahead for two hundred yards and then take the first right turn\",           \"fromUserId\": 50210,           \"timestamp\": 1533197225000,           \"toUserId\": 78596       },       {           \"content\": \"It's a privilege and an honour to have known you\",           \"fromUserId\": 78596,           \"timestamp\": 1533118270000,           \"toUserId\": 50210       }    ],    \"userId\": 50210,    \"users\": [        {            \"avatar\": \"octocat.jpg\",            \"firstName\": \"John\",            \"lastName\": \"Doe\",            \"id\": 67452        },        {            \"avatar\": \"genie.png\",            \"firstName\": \"Michael\",            \"lastName\": \"Crowley\",            \"id\": 78596        }    ]}");
            return ds;
        }
        /// <summary>
        /// send the result via an HTTP POST
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private async Task<bool> SubmitInboxView(Result result)
        {
            
            string jsonData = JsonSerializer.Serialize<Result>(result);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(String.Format(QUERY, BASE_URL, "result", API_KEY), content);
            return response.IsSuccessStatusCode;
        }       
    }

}
