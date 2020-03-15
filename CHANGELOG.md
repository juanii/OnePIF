# Changelog

## [0.5.2](https://github.com/juanii/OnePIF/releases/0.5.2) - 2020-03-14

### Fixed

* Map router IP to URL field in Wireless Routers items.

## [0.5.1](https://github.com/juanii/OnePIF/releases/0.5.1) - 2020-03-11

### Fixed

* Broken newline conversion in multiline fields.

## [0.5.0](https://github.com/juanii/OnePIF/releases/0.5.0) - 2019-01-26

### Added

* Support for older 1pif file format without sections (1Password 3 for Mac OS X).

### Fixed

* Some misspelled field names.

## [0.4.0](https://github.com/juanii/OnePIF/releases/0.4.0) - 2019-01-12

### Added

* Support for legacy item types: Email Account (v1), iTunes, MySQL Database, FTP Account, iCloud (a.k.a. MobileMe), Generic Account, Instant Messenger, Internet Provider and Amazon S3 (a.k.a. Amazon Web Services).
* Multi-line address format in a single field.
* Support for encoded item UUIDs in 1Password.com vaults.

### Changed

* The user name and URL/server fields of each item type (where applicable) is set as the entry username and URL. The original fields are filled with placeholders to the entry's username and URL.

### Fixed

* Regression importing non-empty user-defined section titles.
* Several address formatting bugs.

## [0.3.3](https://github.com/juanii/OnePIF/releases/0.3.3) - 2019-01-07

### Fixed

* Crash when importing sections with no fields.
* Password data was overwritten with a placeholder if the password field title in the 1pif file collides with KeePass password field name.

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
