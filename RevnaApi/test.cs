using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using NUnit.Framework;

namespace RevnaApi
{
    [TestFixture]
    public class TestAPI
    {
//        static string slackjson = @"{
//	'token': 'z26uFbvR1xHJEdHE1OQiO6t8',
//	'team_id': 'T061EG9RZ',
//	'api_app_id': 'A0FFV41KK',
//	'event': {
//		'type': 'reaction_added',
//		'user': 'U061F1EUR',
//		'item': {
//			'type': 'message',
//			'channel': 'C061EG9SL',
//			'ts': '1464196127.000002'

//        },
//		'reaction': 'slightly_smiling_face',
//		'item_user': 'U0M4RL1NY',
//		'event_ts': '1465244570.336841'
//	},
//	'type': 'event_callback',
//	'authed_users': [
//		'U061F7AUR'
//	],
//	'authorizations': [
//        {
//            'enterprise_id': 'E12345',
//            'team_id': 'T12345',
//            'user_id': 'U12345',
//            'is_bot': false
//        }
//    ],
//	'event_id': 'Ev9UQ52YNA',
//	'event_context': 'EC12345',
//	'event_time': 1234567890
//}";

        [Test]
        public void Test()
        {
            var url = "http://192.168.0.109:80/Revna/api/values";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ContentType = "application/json";

            var data = new Dictionary<string, string>()
            {
                {"key", "value" }
            };

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();
            //}

            TestContext.Out.WriteLine(httpResponse.StatusCode);
            TestContext.Out.WriteLine(url);
        }
    }
    
}