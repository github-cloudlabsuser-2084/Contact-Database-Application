$resourceGroupName = "GitHub-Copilot-Challenges"
$deploymentName = "contact-db"
$bicepFilePath = "./main.bicep"

az deployment group create --resource-group $resourceGroupName --name $deploymentName --template-file $bicepFilePath