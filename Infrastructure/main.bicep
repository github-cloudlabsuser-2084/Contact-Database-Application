param appName string = 'contact-database'
param location string = 'australiaeast'

resource appServicePlan 'Microsoft.Web/serverfarms@2021-02-01' = {
    name: '${appName}-plan'
    location: location
    sku: {
        name: 'B1'
        tier: 'Basic'
    }
    properties: {
        reserved: true
    }
}

resource webApp 'Microsoft.Web/sites@2021-02-01' = {
    name: appName
    location: location
    properties: {
        serverFarmId: appServicePlan.id
    }
}
