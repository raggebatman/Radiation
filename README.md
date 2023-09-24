# Radiation

Radiation is a plugin that's made to stop people from
extending rounds too much.
It works by ticking away players' health, starting at a configurable time
after the Alpha Warhead has detonated.
You can choose which roles will take damage and you can choose how that
damage is applied.
View the config file for details.

## Commands

Radiation is managed using the `radiation` command.

- `radiation start`
- `radiation stop`
- `radiation enable`
- `radiation disable`

Start/Stop is used to manage whether or not the radiation is ticking damage.

Enable/Disable is used to manage whether or not the radiation will begin.
Useful if you want to disable the plugin temporarily for some reason.

With the config key `enable_radiation_on_round_start` you can make sure
that radiation always is enabled, no matter if a moderator disabled it
on the previous round.

## Permissions

Each command has its own permission.

- `radiation.start`
- `radiation.stop`
- `radiation.enable`
- `radiation.disable`

## Details

License: MIT

Framework: NwPluginApi

Requires: NWAPIPermissionSystem