/*
 * Copyright 2010-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
    using System;
    using System.Collections.Generic;
    using System.IO;
    using ThirdParty.Json.LitJson;
    using Amazon.ElasticMapReduce.Model;
    using Amazon.Runtime.Internal.Transform;

    namespace Amazon.ElasticMapReduce.Model.Internal.MarshallTransformations
    {
      /// <summary>
      /// HadoopJarStepConfigUnmarshaller
      /// </summary>
      internal class HadoopJarStepConfigUnmarshaller : IUnmarshaller<HadoopJarStepConfig, XmlUnmarshallerContext>, IUnmarshaller<HadoopJarStepConfig, JsonUnmarshallerContext>
      {
        HadoopJarStepConfig IUnmarshaller<HadoopJarStepConfig, XmlUnmarshallerContext>.Unmarshall(XmlUnmarshallerContext context)
        {
          throw new NotImplementedException();
        }

        public HadoopJarStepConfig Unmarshall(JsonUnmarshallerContext context)
        {
            if (context.CurrentTokenType == JsonToken.Null)
                return null;

            HadoopJarStepConfig hadoopJarStepConfig = new HadoopJarStepConfig();

        
        
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            while (context.Read())
            {
              
              if (context.TestExpression("Properties", targetDepth))
              {
                context.Read();
                
                if (context.CurrentTokenType == JsonToken.Null)
                {
                    hadoopJarStepConfig.Properties = null;
                    continue;
                }
                  hadoopJarStepConfig.Properties = new List<KeyValue>();
                  KeyValueUnmarshaller unmarshaller = KeyValueUnmarshaller.GetInstance();
                while (context.Read())
                {
                  JsonToken token = context.CurrentTokenType;                
                  if (token == JsonToken.ArrayStart)
                  {
                    continue;
                  }
                  if (token == JsonToken.ArrayEnd)
                  {
                    break;
                  }
                   hadoopJarStepConfig.Properties.Add(unmarshaller.Unmarshall(context));
                }
                continue;
              }
  
              if (context.TestExpression("Jar", targetDepth))
              {
                context.Read();
                hadoopJarStepConfig.Jar = StringUnmarshaller.GetInstance().Unmarshall(context);
                continue;
              }
  
              if (context.TestExpression("MainClass", targetDepth))
              {
                context.Read();
                hadoopJarStepConfig.MainClass = StringUnmarshaller.GetInstance().Unmarshall(context);
                continue;
              }
  
              if (context.TestExpression("Args", targetDepth))
              {
                context.Read();
                
                if (context.CurrentTokenType == JsonToken.Null)
                {
                    hadoopJarStepConfig.Args = null;
                    continue;
                }
                  hadoopJarStepConfig.Args = new List<String>();
                  StringUnmarshaller unmarshaller = StringUnmarshaller.GetInstance();
                while (context.Read())
                {
                  JsonToken token = context.CurrentTokenType;                
                  if (token == JsonToken.ArrayStart)
                  {
                    continue;
                  }
                  if (token == JsonToken.ArrayEnd)
                  {
                    break;
                  }
                   hadoopJarStepConfig.Args.Add(unmarshaller.Unmarshall(context));
                }
                continue;
              }
  
                if (context.CurrentDepth <= originalDepth)
                {
                    return hadoopJarStepConfig;
                }
            }
          

            return hadoopJarStepConfig;
        }

        private static HadoopJarStepConfigUnmarshaller instance;
        public static HadoopJarStepConfigUnmarshaller GetInstance()
        {
            if (instance == null)
                instance = new HadoopJarStepConfigUnmarshaller();
            return instance;
        }
    }
}
  
