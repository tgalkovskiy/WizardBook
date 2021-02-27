using System;
using Newtonsoft.Json;

public class JsonSerializer
{
    public static string Serialize(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static T Deserizliaer<T>(string obj)
    {
        return JsonConvert.DeserializeObject<T>(obj);
    }

    public static object Deserizliaer(string obj, Type type)
    {
        return JsonConvert.DeserializeObject(obj, type);
    }
}