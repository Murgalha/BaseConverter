# BaseConverter
An unsigned 64-bit numeric system converter, made as a WPF App on Visual Studio.

![Main screen of Base Converter](https://user-images.githubusercontent.com/23103524/31574716-6367ab4e-b0ab-11e7-8adb-cbeac7f23e3f.PNG)

## Install
There is no need to install the app, you can simply download and execute the *BaseConverter.exe* file available on the *bin/* folder.
Works only on Windows.

## Usage
The app has one simple screen containing two convertion boxes where you enter the number on the left box and convert the numeral system "from X to Y", appearing on the right one. There is also a swap button to change convertion to "from Y to X". The available systems are:
* **Decimal**
* **Binary**
* **Hexadecimal**
* **Octal**

## Format
Before the conversion, a format check is made to see if the number entered is shorter than 64 bits or it fits the numeric system format (i.e. octal numbers have only digits from 0 to 7). If any of these requirements are not met, an error message is shown.