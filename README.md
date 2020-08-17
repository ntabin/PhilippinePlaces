# Philippine Places
Api for Philippine Regions, Provinces, Cities, and barangays

For the reference JSON file I use [this](https://github.com/clavearnel/philippines-region-province-citymun-brgy/tree/master/json)
The root url is https://philippine-places.herokuapp.com/

## Api Reference
**Regions**
----
  Get one or all regions

* **URL**

  /api/regions

* **Method:**

  `GET`
  
*  **URL Params**
   **Optional:**
 
   `region=[string]`
   `includeProvinces=[boolean]`
   `includeCities=[string]`
   `includeBarangays=[string]`

* **Success Response:**
  
  <_What should the status code be on success and is there any returned data? This is useful when people need to to know what their callbacks should expect!_>

  * **Code:** 200 <br />
    **Content:** `[
   {
      "code":"01",
      "name":"REGION I (ILOCOS REGION)",
      "provinces":[
         {
            "code":"0128",
            "name":"ILOCOS NORTE"
         },
         {
            "code":"0129",
            "name":"ILOCOS SUR"
         },
         {
            "code":"0133",
            "name":"LA UNION"
         },
         {
            "code":"0155",
            "name":"PANGASINAN"
         }
      ]
   }
]`
* **Sample Call:**

  https://philippine-places.herokuapp.com/api/regions?region=01&includeProvinces=true

* **Notes:**

  **region** params refers to the region code
  **includeProvinces, includeCities and includeBarangays** params defaults to false
  
**Provinces**
----
  Get provinces per region

* **URL**

  api/province

* **Method:**

  `GET`
  
*  **URL Params**
   **Required:**
 
   `region=[string]`

   **Optional:**
   `includeCities=[string]`
   `includeBarangays=[string]`

* **Success Response:**
  
  <_What should the status code be on success and is there any returned data? This is useful when people need to to know what their callbacks should expect!_>

  * **Code:** 200 <br />
    **Content:** `[{"code":"0128","name":"ILOCOS NORTE"},{"code":"0129","name":"ILOCOS SUR"},{"code":"0133","name":"LA UNION"},{"code":"0155","name":"PANGASINAN"}]`
    
* **Sample Call:**

  https://philippine-places.herokuapp.com/api/provinces?region=01

* **Notes:**
  **region** params refers to the region code
  
**Cities**
----
  Get Cities per province

* **URL**

  api/cities

* **Method:**
  `GET`
  
*  **URL Params**

   <_If URL params exist, specify them in accordance with name mentioned in URL section. Separate into optional and required. Document data constraints._> 

   **Required:**
 
   `province=[string]`

   **Optional:**
 
   `includeBarangays=[string]`
   
* **Success Response:**
  
  <_What should the status code be on success and is there any returned data? This is useful when people need to to know what their callbacks should expect!_>

  * **Code:** 200 <br />
    **Content:** `[{"code":"012801","name":"ADAMS"},{"code":"012802","name":"BACARRA"},{"code":"012803","name":"BADOC"},{"code":"012804","name":"BANGUI"},{"code":"012805","name":"CITY OF BATAC"},{"code":"012806","name":"BURGOS"},{"code":"012807","name":"CARASI"},{"code":"012808","name":"CURRIMAO"},{"code":"012809","name":"DINGRAS"},{"code":"012810","name":"DUMALNEG"},{"code":"012811","name":"BANNA (ESPIRITU)"},{"code":"012812","name":"LAOAG CITY (Capital)"},{"code":"012813","name":"MARCOS"},{"code":"012814","name":"NUEVA ERA"},{"code":"012815","name":"PAGUDPUD"},{"code":"012816","name":"PAOAY"},{"code":"012817","name":"PASUQUIN"},{"code":"012818","name":"PIDDIG"},{"code":"012819","name":"PINILI"},{"code":"012820","name":"SAN NICOLAS"},{"code":"012821","name":"SARRAT"},{"code":"012822","name":"SOLSONA"},{"code":"012823","name":"VINTAR"}]`

* **Sample Call:**

  https://philippine-places.herokuapp.com/api/cities?province=0128

* **Notes:**
  **province** params refers to the province code
 
 **Barangays**
----
  Get Barangays per city

* **URL**

  api/barangays

* **Method:**
  `GET`
  
*  **URL Params**

   <_If URL params exist, specify them in accordance with name mentioned in URL section. Separate into optional and required. Document data constraints._> 

   **Required:**
 
   `city=[string]`

* **Success Response:**
  
  <_What should the status code be on success and is there any returned data? This is useful when people need to to know what their callbacks should expect!_>

  * **Code:** 200 <br />
    **Content:** `[{"code":"012802001","name":"Bani"},{"code":"012802002","name":"Buyon"},{"code":"012802003","name":"Cabaruan"},{"code":"012802004","name":"Cabulalaan"},{"code":"012802005","name":"Cabusligan"},{"code":"012802006","name":"Cadaratan"},{"code":"012802007","name":"Calioet-Libong"},{"code":"012802008","name":"Casilian"},{"code":"012802009","name":"Corocor"},{"code":"012802011","name":"Duripes"},{"code":"012802012","name":"Ganagan"},{"code":"012802013","name":"Libtong"},{"code":"012802014","name":"Macupit"},{"code":"012802015","name":"Nambaran"},{"code":"012802016","name":"Natba"},{"code":"012802017","name":"Paninaan"},{"code":"012802018","name":"Pasiocan"},{"code":"012802019","name":"Pasngal"},{"code":"012802020","name":"Pipias"},{"code":"012802021","name":"Pulangi"},{"code":"012802022","name":"Pungto"},{"code":"012802024","name":"San Agustin I (Pob.)"},{"code":"012802025","name":"San Agustin II (Pob.)"},{"code":"012802027","name":"San Andres I (Pob.)"},{"code":"012802028","name":"San Andres II (Pob.)"},{"code":"012802030","name":"San Gabriel I (Pob.)"},{"code":"012802031","name":"San Gabriel II (Pob.)"},{"code":"012802033","name":"San Pedro I (Pob.)"},{"code":"012802034","name":"San Pedro II (Pob.)"},{"code":"012802036","name":"San Roque I (Pob.)"},{"code":"012802037","name":"San Roque II (Pob.)"},{"code":"012802039","name":"San Simon I (Pob.)"},{"code":"012802040","name":"San Simon II (Pob.)"},{"code":"012802041","name":"San Vicente (Pob.)"},{"code":"012802042","name":"Sangil"},{"code":"012802044","name":"Santa Filomena I (Pob.)"},{"code":"012802045","name":"Santa Filomena II (Pob.)"},{"code":"012802046","name":"Santa Rita (Pob.)"},{"code":"012802047","name":"Santo Cristo I (Pob.)"},{"code":"012802048","name":"Santo Cristo II (Pob.)"},{"code":"012802050","name":"Tambidao"},{"code":"012802051","name":"Teppang"},{"code":"012802052","name":"Tubburan"}]`
 
* **Sample Call:**

  https://philippine-places.herokuapp.com/api/barangays?city=012802

* **Notes:**

  **city** params refers to the city code
