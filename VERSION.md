# History

## 1.1.0

Minor release.

Summary:

- New command `radiation status`

- Checks for if hints can be displayed when players change roles (e.g. on spawn)

Added:

- Command `Commands.StatusCommand`

- Event `ServerEvents.OnPlayerChangeRole()`

- Enum `Enums.RadiationDamage`

- Method `RadiationAPI.RadiationDamageType()`

- Overloads for `RadiationAPI.ShowHint()`, `RadiationAPI.DealDamage()`, `RadiationAPI.RadiationDamageType()`

- Property `Plugin.radiationDelayed`

Changed:

- Removed `Plugin.StartRadiation()` from `Plugin.EnableRadiation()`

- `Plugin.Singleton` setter is now private

- `Plugin.radiationEnabled` and `Plugin.radiationStarted` getters are now public

- Improved logic in general

- Janitored the config and updated the example

- `AssemblyVersion` and `AssemblyFileVersion` to be more or less compliant

## 1.0.0

Initial release.