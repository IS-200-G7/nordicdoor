# JWT - JSON Web Tokens

Hentet fra: https://jwt.io/

### Hva er JSON Web Token ?

JSON Web Token (JWT) som definerer en kompakt og selvstendig måte for sikker overføring av informasjon mellom parter som
et JSON-objekt. Denne informasjonen kan verfiseres og stole på fordi den er digitalt signert.
JWT-er kan signeres ved hjelp av en hemmelighet (med HMAC - algoritmen) eller et offentlig/privat nøkkelpar ved å bruke
RSA eller ECDSA.

Selv om JWT-er kan krypteres for også å gi hemmelighold mellom parter, fokuserer JWT på signerte tokens. Signerte tokens
kan bekrefte integriteten til påstandene i den, mens krypterte token skjuler disse påstandene fra andre parter. Når
token er signerte ved bruk av offentlige/private nøkkelpar, bekrefter signaturen også at bare den som har den private
nøkkelen er den som signerte den.

### Når bør du bruke JSON Web Tokens?

***Autorisasjon***: Dette er det vabklugste scenarioet for bruk av JWT. Når brukeren er logget på, vil hver påfølgende
forespørsel inkludere JWT, som lar brukeren få tilgang til ruter, tjenester og ressurser som er tillatt med det tokenet.
Eksempelvis er tilgang til APIèr og Views.

***Informasjonsutveksling***: JSON Web Tokens er en god måte å sikkert overføre informasjon mellom parter på. Fordi
JWT-er kan signeres, kan du være sikker på at avsenderne er den de sier de er.

## JSON Web Token-Struktur

Består av tre deler atskilt med prikker ( . )

* Overskrift
* Nyttelast
* Signatur

En JWT kan se slik ut
<p style="color:red">xxxxx.yyyyy.zzzzz </p>

### Overskrift - "xxxxx"

```JSON
{
	"alg" : "HS256",
	"typ" : "JWT"
}
```

Består av to deler: typen token, som er JWT, og signeringsalgoritmen som brukes. I dette tilfelle er det HS256 som
brukes.

### Nyttelast - "yyyyy"

```JSON
{
	"sub": "1234567890",
	"name": "Torkel Ivarsøy",
	"admin": true
}
```

Nyttelasten inneholder kravene. Påstander er utsagn om en enhet (vanlgivis brukeren) og tilleggsdata. Det er tre typer
krav:

* Registrerte krav
* Offentlige krav
* Private krav

***Registrerte krav***: Dette er et sett med forhåndsdefinerte krav som ikke er obligatoriske, men anbefalt, for å gi et
sett med nyttig, interoperable krav. Noen av dem er:**iss**(utsteder),**exp**(utløpstid),**sub**(emne),**aud**(publikum)
.

***Offentlige krav***: Disse kan defineres etter eget ønske av de som bruker JWT-er.

***Private krav***: Dette er de tilpassede kravene opprettet for å dele informasjon mellom parter som er enige om å
bruke dem og er verken registrerte eller offentlige krav.

### Signatur - "zzzzz"

For å lage signaturdelen tar man den kodede overskriften, den kodede nyttelasten, en hemmlighet, algoritmen spesifisert
i overskriften, og signere det.

```cs
HMACSHA256( base64UrlEncode(header) + "." + base64UrlEncode(payload), secret)
}
```

Signaturen brukes til å bekrefte at meldingen ikke lbe endret underveis, og i tilfelle av token signert med en privat
nøkkel, kan den også bekrefte at avsenderen av JWT er den den sier den er.

# Hvordan bruke JWT

Når brukeren ønsker å få tilgang til en beskyttet rute eller ressurs, bør brukeragenten sende JWT, vanligvis i**
autorisasjonsoverskriften**ved å bruke**bærerskjemaet**. Innholdet i overskriften skal se slik ut:

```
Authorization: Bearer <token>
```

Dette kan i visse tilfeller være en statsløs autorisasjonsmekanisme. Serverens beskyttede ruter vil se etter en gyldig
JWT i`Authorization`overskriften, og hvis den er til stede, vil brukeren få tilgang til beskyttede ressurser.
