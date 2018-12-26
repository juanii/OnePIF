# Changelog

## [0.3.2](https://github.com/juanii/OnePIF/releases/0.3.2) - 2018-12-25

### Changed

* Previously used passwords are handled the KeePass way: each history entry is fully populated (using main entry data).

* The main concealed field of each item type is set as the entry password, and the original field contains a placeholder to the entry password.

### Fixed

* The main item URL was also being added as a secondary URL.

## [0.3.1](https://github.com/juanii/OnePIF/releases/0.3.1) - 2018-12-22

### Fixed

* Wrong data types in entity classes to parse 1pif causing crashes.
* Crash when parsing incomplete address fields.
* Tab order in configuration window.

## [0.3.0](https://github.com/juanii/OnePIF/releases/0.3.0) - 2018-12-21

### Added

* Option to import addresses in compact (one field) or expanded (multiple fields) format.

### Changed

* Proper setup of OTP fields using KeeWeb, Tray TOTP or KeeOtp format.
* Custom address layout by country.

### Fixed

* Error while importing a section without fields.
* The "region" field of an address was ignored.

## [0.2.0](https://github.com/juanii/OnePIF/releases/0.2.0) - 2018-12-19

### Added

* Import attachments.
* Support for files exported by 1Password 4 for Windows.

### Changed

* Ignore "button" and "submit" fields in web forms.

### Fixed

* Error while importing a password item which does not contain a password.

## [0.1.0](https://github.com/juanii/OnePIF/releases/0.1.0) - 2018-12-16

* Initial release.
