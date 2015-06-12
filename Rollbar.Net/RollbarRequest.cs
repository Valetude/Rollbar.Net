﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rollbar {
    [JsonConverter(typeof (ArbitraryKeyConverter))]
    public class RollbarRequest : HasArbitraryKeys {
        public string Url { get; set; }

        public string Method { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public Dictionary<string, object> Params { get; set; }

        public Dictionary<string, object> GetParams { get; set; }

        public string QueryString { get; set; }

        public Dictionary<string, object> PostParams { get; set; }

        public string PostBody { get; set; }

        public string UserIp { get; set; }

        protected override void Normalize() {
            Url = (string) (AdditionalKeys.ContainsKey("url") ? AdditionalKeys["url"] : null);
            AdditionalKeys.Remove("url");
            Method = (string) (AdditionalKeys.ContainsKey("method") ? AdditionalKeys["method"] : null);
            AdditionalKeys.Remove("method");
            Headers = (Dictionary<string, string>) (AdditionalKeys.ContainsKey("headers") ? AdditionalKeys["headers"] : null);
            AdditionalKeys.Remove("headers");
            Params = (Dictionary<string, object>) (AdditionalKeys.ContainsKey("params") ? AdditionalKeys["params"] : null);
            AdditionalKeys.Remove("params");
            GetParams = (Dictionary<string, object>) (AdditionalKeys.ContainsKey("get_params") ? AdditionalKeys["get_params"] : null);
            AdditionalKeys.Remove("get_params");
            QueryString = (string) (AdditionalKeys.ContainsKey("query_string") ? AdditionalKeys["query_string"] : null);
            AdditionalKeys.Remove("query_string");
            PostParams = (Dictionary<string, object>) (AdditionalKeys.ContainsKey("post_params") ? AdditionalKeys["post_params"] : null);
            AdditionalKeys.Remove("post_params");
            PostBody = (string) (AdditionalKeys.ContainsKey("post_body") ? AdditionalKeys["post_body"] : null);
            AdditionalKeys.Remove("post_body");
            UserIp = (string) (AdditionalKeys.ContainsKey("user_ip") ? AdditionalKeys["user_ip"] : null);
            AdditionalKeys.Remove("user_ip");
        }

        protected override Dictionary<string, object> Denormalize(Dictionary<string, object> dict) {
            if (Url != null) {
                dict["url"] = Url;
            }
            if (Method != null) {
                dict["method"] = Method;
            }
            if (Headers != null) {
                dict["headers"] = Headers;
            }
            if (Params != null) {
                dict["params"] = Params;
            }
            if (GetParams != null) {
                dict["get_params"] = GetParams;
            }
            if (QueryString != null) {
                dict["query_string"] = QueryString;
            }
            if (PostParams != null) {
                dict["post_params"] = PostParams;
            }
            if (PostBody != null) {
                dict["post_body"] = PostBody;
            }
            if (UserIp != null) {
                dict["user_ip"] = UserIp;
            }
            return dict;
        }
    }
}
