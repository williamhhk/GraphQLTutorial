$url = "http://localhost:58001/api/graphql"
$input = "Test"

$json = @{
    query = "mutation (`$item:ItemInput!) {createName(item:`$item){name}}"
    variables = @{"item" = @{ "name" = $input}}
    }
$body = $json | ConvertTo-Json
$body
$headers = @{
    "Content-Type" = "application/json"
}

$response = Invoke-WebRequest -Uri $url -Method POST -Body $body -Headers $headers | ConvertFrom-Json
$response.data.createName
