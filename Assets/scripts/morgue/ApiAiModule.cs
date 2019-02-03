//
// API.AI Unity SDK Sample
// =================================================
//
// Copyright (C) 2015 by Speaktoit, Inc. (https://www.speaktoit.com)
// https://www.api.ai
//
// ***********************************************************************************************************************
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
//
// ***********************************************************************************************************************

using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Reflection;
using ApiAiSDK;
using ApiAiSDK.Model;
using ApiAiSDK.Unity;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

public class ApiAiModule : MonoBehaviour
{
    private ApiAiUnity apiAiUnity;
    private AudioSource aud;

    private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
    { 
        NullValueHandling = NullValueHandling.Ignore,
    };

    private readonly Queue<Action> ExecuteOnMainThread = new Queue<Action>();

    // Use this for initialization
    void Start()
    {
        ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) =>
        {
            return true;
        };
            
        const string ACCESS_TOKEN = "937df1a477c3487b922a953bf4892684  ";

        var config = new AIConfiguration(ACCESS_TOKEN, SupportedLanguage.Spanish);

        apiAiUnity = new ApiAiUnity();
        apiAiUnity.Initialize(config);
    }
    
    public String SendText(String question)
    {
        AIResponse response = apiAiUnity.TextRequest(question);

        if (response != null)
        {
            Debug.Log("Resolved query: " + response.Result.ResolvedQuery);
            var outText = JsonConvert.SerializeObject(response, jsonSettings);

            var pattern = @"speech"":""(.+?)""";
            var match = Regex.Match(outText, pattern);

            Debug.Log("Result: " + match.Groups[1]);

            
            return match.Groups[1].ToString();
            //tryToDoAction(match.Groups[1].ToString());
        } else
        {
            return "Response is null";
        }

    }

    private string replaceStrangeCharacters(string badMessage)
    {
        string message = badMessage;
        message = message.Replace("\u00c0", "�");
        message = message.Replace("\u00c1", "�");
        message = message.Replace("\u00c2", "�");
        message = message.Replace("\u00c3", "�");
        message = message.Replace("\u00c4", "�");
        message = message.Replace("\u00c5", "�");
        message = message.Replace("\u00c6", "�");
        message = message.Replace("\u00c7", "�");
        message = message.Replace("\u00c8", "�");
        message = message.Replace("\u00c9", "�");
        message = message.Replace("\u00ca", "�");
        message = message.Replace("\u00cb", "�");
        message = message.Replace("\u00cc", "�");
        message = message.Replace("\u00cd", "�");
        message = message.Replace("\u00ce", "�");
        message = message.Replace("\u00cf", "�");
        message = message.Replace("\u00d1", "�");
        message = message.Replace("\u00d2", "�");
        message = message.Replace("\u00d3", "�");
        message = message.Replace("\u00d4", "�");
        message = message.Replace("\u00d5", "�");
        message = message.Replace("\u00d6", "�");
        message = message.Replace("\u00d8", "�");
        message = message.Replace("\u00d9", "�");
        message = message.Replace("\u00da", "�");
        message = message.Replace("\u00db", "�");
        message = message.Replace("\u00dc", "�");
        message = message.Replace("\u00dd", "�");
        message = message.Replace("\u00df", "�");
        message = message.Replace("\u00e0", "�");
        message = message.Replace("\u00e1", "�");
        message = message.Replace("\u00e2", "�");
        message = message.Replace("\u00e3", "�");
        message = message.Replace("\u00e4", "�");
        message = message.Replace("\u00e5", "�");
        message = message.Replace("\u00e6", "�");
        message = message.Replace("\u00e7", "�");
        message = message.Replace("\u00e8", "�");
        message = message.Replace("\u00e9", "�");
        message = message.Replace("\u00ea", "�");
        message = message.Replace("\u00eb", "�");
        message = message.Replace("\u00ec", "�");
        message = message.Replace("\u00ed", "�");
        message = message.Replace("\u00ee", "�");
        message = message.Replace("\u00ef", "�");
        message = message.Replace("\u00f0", "�");
        message = message.Replace("\u00F1", "�");
        message = message.Replace("\u00f2", "�");
        message = message.Replace("\u00f3", "�");
        message = message.Replace("\u00f4", "�");
        message = message.Replace("\u00f5", "�");
        message = message.Replace("\u00f6", "�");
        message = message.Replace("\u00f8", "�");
        message = message.Replace("\u00f9", "�");
        message = message.Replace("\u00fa", "�");
        message = message.Replace("\u00fb", "�");
        message = message.Replace("\u00fc", "�");
        message = message.Replace("\u00fd", "�");
        message = message.Replace("\u00ff", "�");

        return message;
    }
}
