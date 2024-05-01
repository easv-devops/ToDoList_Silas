using FeatureHubSDK;

namespace ToDoList_Front.Clients;

public class FeatureClient
{
    private readonly EdgeFeatureHubConfig _featureHubConfig;

    public FeatureClient(string url, string apiKey)
    {
        _featureHubConfig = new EdgeFeatureHubConfig(url, apiKey);
    }

    public async Task<bool> IsEnabled(string featureKey)
    {
        var context = await _featureHubConfig.NewContext().Build();
        return context[featureKey].IsEnabled;
    }
}