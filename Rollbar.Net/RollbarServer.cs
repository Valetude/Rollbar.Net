﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rollbar {
    [JsonConverter(typeof (ArbitraryKeyConverter))]
    public class RollbarServer : HasArbitraryKeys {
        public string Host { get; set; }

        public string Root { get; set; }

        public string Branch { get; set; }

        public string CodeVersion { get; set; }

        protected override void Normalize() {
            Host = (string) (AdditionalKeys.ContainsKey("host") ? AdditionalKeys["host"] : null);
            AdditionalKeys.Remove("host");
            Root = (string) (AdditionalKeys.ContainsKey("root") ? AdditionalKeys["root"] : null);
            AdditionalKeys.Remove("root");
            Branch = (string) (AdditionalKeys.ContainsKey("branch") ? AdditionalKeys["branch"] : null);
            AdditionalKeys.Remove("branch");
            CodeVersion = (string) (AdditionalKeys.ContainsKey("code_version") ? AdditionalKeys["code_version"] : null);
            AdditionalKeys.Remove("code_version");
        }

        protected override Dictionary<string, object> Denormalize(Dictionary<string, object> dict) {
            if (Host != null) {
                dict["host"] = Host;
            }
            if (Root != null) {
                dict["root"] = Root;
            }
            if (Branch != null) {
                dict["branch"] = Branch;
            }
            if (CodeVersion != null) {
                dict["code_version"] = CodeVersion;
            }
            return dict;
        }
    }
}
