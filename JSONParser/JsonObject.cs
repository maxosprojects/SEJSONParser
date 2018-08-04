﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONParser
{
    public class JsonObject : JsonElement, IJsonNonPrimitive
    {
        private Dictionary<string, JsonElement> Value;

        public override JSONValueType ValueType
        {
            get
            {
                return JSONValueType.NESTED;
            }
        }

        public JsonElement this[string key]
        {
            get
            {
                return Value[key];
            }
        }

        public Dictionary<string,JsonElement>.KeyCollection Keys
        {
            get
            {
                return Value.Keys;
            }
        }

        public bool ContainsKey(string key)
        {
            return Value.ContainsKey(key);
        }


        public JsonObject(string key, bool readOnly = true)
        {
            Key = key;
            Value = new Dictionary<string, JsonElement>();
        }

        public void Add(JsonElement jsonObj)
        {
            Value.Add(jsonObj.Key, jsonObj);
        }

        public override string ToString(bool pretty = true)
        {
            var result = "";
            if(Key != "" && Key != null)
                result = Key + (pretty? ": " : ":");
            result += "{";
            foreach(var kvp in Value)
            {
                var childResult = kvp.Value.ToString(pretty);
                if (pretty)
                    childResult = childResult.Replace("\n", "\n  ");
                result += (pretty? "\n  " : "") + childResult + ",";
            }
            result = result.Substring(0, result.Length - 1);
            result += (pretty? "\n}" : "}");

            return result;
        }
    }
}
