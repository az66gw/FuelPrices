# FuelPrices

Spritpreise über die Tankerkönig-API (Datenlizenz CC BY 4.0: Namensnennung „Tankerkönig“ nötig).
Projektwissen (API-Fakten, Key-Stand, verworfene Alternativen) steht im Gedächtnis des Projekts (`fuelprices_project.md`), nicht hier.

## Aufbau
- `FuelPrices.Core`: `TankerkoenigClient` (aktuell nur `list.php`), Modelle, `PriceJsonConverter` (API liefert `false` statt `null` bei fehlendem Preis).
- `FuelPrices.Explorer`: WinForms-Tool zum Finden von Tankstellen-IDs.
- Ein Dienst (Worker-Service) kommt später in dasselbe Verzeichnis. **Sein Zweck ist bewusst noch offen**: nichts annehmen (Alarm? Historie?), erst Andreas fragen.

## Regeln
- Name bleibt „FuelPrices“, nicht „Tankerkoenig“ (Datenquelle soll austauschbar bleiben).
- `FuelPricesConfig.json` enthält den API-Key, ist gitignored und wird nie committet oder in Chats wiederholt. Beim ersten Start legt `Program.LoadOrCreateConfig` eine leere Vorlage an.
- Ein einziger langlebiger `HttpClient` (in `Program.cs`), keine neuen pro Aufruf.
- API-Limit: offiziell 1 Anfrage/Minute, bei automatischem Abruf höchstens alle 5 Minuten.
- Code: englische Bezeichner, PascalCase-Felder, `GetAllByX` für Listenergebnisse, klassisches `Program.Main`. Tests (falls es welche gibt) mit xunit.v3.
- Neue Dienste und Deployment wie im Muster Trading212 / FinTSExplorer (siehe globale CLAUDE.md).
- Chats zu diesem Projekt gehören in diesen Ordner, nicht nach Trading212.

## Bauen und Starten
```
dotnet build FuelPrices.slnx
```
Der Explorer liest `FuelPricesConfig.json` aus seinem Ausgabeordner (`FuelPrices.Explorer\bin\Debug\net10.0-windows\`). Der öffentliche Demo-Key (`00000000-0000-0000-0000-000000000002`) liefert echte Stationen mit erfundenen Preisen.

Git: direkt auf `master`, Remote `https://github.com/az66gw/FuelPrices`.
