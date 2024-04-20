# User App for 3rd year Uni project.
## Integrating Arduino Serial Output with windows form (.NET framework) [C#]

The aim of the app is to improve the user experience in the acclimation period faced when, for the first time or whenever they feel insecure, using a powered prosthetic finger.

Currently the project is in first release, with basic functionality achieved.
Although still very much in beta with boundless room for improvement.

A build has been published and is avilable for download upon request (although the app can be operated by opening in Visual Studio)

> Visual enhancement (dark mode) darkmode.cs from - https://github.com/BlueMystical/Dark-Mode-Forms


### Although, some stuff that I would have liked to get included, did not. The project focus shifted to integration and generating analytics, so this app got left behind. Furthermore, we were only given one final mechanical design to test so the medium and large section of the app had no reason to be developed.
Ideally the app would have generated a hardware failure report when the temperature exceeded a certain level or when the electronics failed, this would be tied in with other internal hidden data. The framework for this did end up being developed but as the duty cycle testing app, with this the functionality could be implemented with relative ease, perhaps.


Before running either program it is important that the arduino is attached to COM port 3. This is relatively easy and is done with the following steps

- press WIN + R
- in the new window paste (to open device manager)
- "devmgmt.msc"
- In view tab at the top select show hidden devices
- Navigate to ports
- If COM3 is occupied by another device
- remove or change the com port number
- RightClick -> Properties -> Port settings -> Advanced -> COM port number
