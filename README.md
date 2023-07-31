# PostApp

Naudijimosi instrukcijos:
1. Nueiti į appsettings.json, kad sukonfiguruoti duomenų bazės prisijungimą
   ![image](https://github.com/PRMantis/PostApp/assets/33916077/d260ad3e-89b5-4e47-8580-ec1ed3c35397)
   ir pakeisti šitas reikšmes į savo. ![image](https://github.com/PRMantis/PostApp/assets/33916077/c6e81ab5-11c0-4386-a517-f675a53c7649)
   Database rekomenduojama palikti KlientuDuomenys, o Server į ką naudosit pas save ![image](https://github.com/PRMantis/PostApp/assets/33916077/ee9fce4e-0b3b-43d3-b478-de0a7a9128e4)

2. Paleisti programą per IIS Express ![image](https://github.com/PRMantis/PostApp/assets/33916077/0f34be7b-b020-494b-8cd5-2f861c32c1c5)
3. Paspaudus Read from JSON File failas bus nuskaitytas. Randamas čia ![image](https://github.com/PRMantis/PostApp/assets/33916077/b8a5626f-3a5d-4cdc-86f8-b2f2ba6ef5fe)
4. Įvedus API Key galima išgauti duomenis ![image](https://github.com/PRMantis/PostApp/assets/33916077/e4088f34-7790-4851-a2a4-c737e7a998be) įvedus neteisingą, duomenis neatsinaujins.
   Šiuo metu nėra padarytas įspėjimas vartotojui, nebent nėra įvestas joks API key. API key visą laiką bus iš kart nustatytas į example key.
5. Pasirinkus adresą iš sąrašo su tinkamu API key, bus atnaujintas to adreso pašto indeksas. ![image](https://github.com/PRMantis/PostApp/assets/33916077/781d9095-9ed5-4b2a-b23f-54e3c1fc6385)
6. Kadangi daugiau adresų nėra importuojama, adreso pašto kodo atnaujinimas padarytas, kad tik būtų įmanoma pasirinkti iš turimų adresų.

!!
Naudojau .NET 7 versija, o savo duomenų bazei naudojau MSSQL Server Developer Edition (pačia naujausią versiją) su MS SQL Server Studio.

