
import requests
from bs4 import BeautifulSoup

#print(response.text)
#print(response.url)
#print(response.content)
#print(response.encoding)
#print(response.headers)
#print(response.json)
#print(response.links)
#print(response.ok)
#print(response.status_code)

url = "https://google.com"
resp = requests.get(url)
print(BeautifulSoup(resp.text, 'html.parser'))