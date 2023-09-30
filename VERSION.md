# History

## 1.1.1

Revision.

Summary:

- Fixed an issue where radiation would start on the next round before warhead detonation.

- New command `radiation version`

Added:

- Command `Commands.VersionCommand`

- Enum `Enums.RadiationStatus`

- Method `RadiationAPI.Status()`

Changed:

- Coroutine tags now use constants rather than unique strings.

- In events that stop radiation, `StopDelay()` now gets called as well as
`StopRadiation()`. Previously only `StopRadiation()` would be called. `StopRadiation()`
does call `StopDelay()` in its body but it is called after the check is done
that determines whether or not radiation has started. The result would be that
the radiation delay coroutine does not get killed when restarting the round if
radiation had not been started, meaning that radiation would "leak through" to
the next round.

- Tuples are now used as return values instead of booleans. This mainly improves
how command feedback is handled.

Removed:

- Permissions `radiation.status` and `radiation.version`, these can now be used
by anyone with access to the Remote Admin console.

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