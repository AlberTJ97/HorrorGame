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
        message = message.Replace("\u00c0", "À");
        message = message.Replace("\u00c1", "Á");
        message = message.Replace("\u00c2", "Â");
        message = message.Replace("\u00c3", "Ã");
        message = message.Replace("\u00c4", "Ä");
        message = message.Replace("\u00c5", "Å");
        message = message.Replace("\u00c6", "Æ");
        message = message.Replace("\u00c7", "Ç");
        message = message.Replace("\u00c8", "È");
        message = message.Replace("\u00c9", "É");
        message = message.Replace("\u00ca", "Ê");
        message = message.Replace("\u00cb", "Ë");
        message = message.Replace("\u00cc", "Ì");
        message = message.Replace("\u00cd", "Í");
        message = message.Replace("\u00ce", "Î");
        message = message.Replace("\u00cf", "Ï");
        message = message.Replace("\u00d1", "Ñ");
        message = message.Replace("\u00d2", "Ò");
        message = message.Replace("\u00d3", "Ó");
        message = message.Replace("\u00d4", "Ô");
        message = message.Replace("\u00d5", "Õ");
        message = message.Replace("\u00d6", "Ö");
        message = message.Replace("\u00d8", "Ø");
        message = message.Replace("\u00d9", "Ù");
        message = message.Replace("\u00da", "Ú");
        message = message.Replace("\u00db", "Û");
        message = message.Replace("\u00dc", "Ü");
        message = message.Replace("\u00dd", "Ý");
        message = message.Replace("\u00df", "ß");
        message = message.Replace("\u00e0", "à");
        message = message.Replace("\u00e1", "á");
        message = message.Replace("\u00e2", "â");
        message = message.Replace("\u00e3", "ã");
        message = message.Replace("\u00e4", "ä");
        message = message.Replace("\u00e5", "å");
        message = message.Replace("\u00e6", "æ");
        message = message.Replace("\u00e7", "ç");
        message = message.Replace("\u00e8", "è");
        message = message.Replace("\u00e9", "é");
        message = message.Replace("\u00ea", "ê");
        message = message.Replace("\u00eb", "ë");
        message = message.Replace("\u00ec", "ì");
        message = message.Replace("\u00ed", "í");
        message = message.Replace("\u00ee", "î");
        message = message.Replace("\u00ef", "ï");
        message = message.Replace("\u00f0", "ð");
        message = message.Replace("\u00F1", "ñ");
        message = message.Replace("\u00f2", "ò");
        message = message.Replace("\u00f3", "ó");
        message = message.Replace("\u00f4", "ô");
        message = message.Replace("\u00f5", "õ");
        message = message.Replace("\u00f6", "ö");
        message = message.Replace("\u00f8", "ø");
        message = message.Replace("\u00f9", "ù");
        message = message.Replace("\u00fa", "ú");
        message = message.Replace("\u00fb", "û");
        message = message.Replace("\u00fc", "ü");
        message = message.Replace("\u00fd", "ý");
        message = message.Replace("\u00ff", "ÿ");

        return message;
    }
}
