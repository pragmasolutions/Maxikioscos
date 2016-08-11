1.Change the urlLocalService addrees in /www/app/services/maxikioscosService.js to: 192.168.1.130:8080

2.Change the urlMasterService address in /www/app/shared/constant.js to: http://maxikioscosservice.azurewebsites.net

3.Generate the apk running the command: 
cordova build --release android

4.Go to the folder where the apk was generated: 
cd platforms/android/build/outputs/apk

5.Copy the keystore file located in: deploys/playstore/maxikioscos-android-release-key.keystore to the folder specified in step 2.
this file must be in the same folder as the apk.

Note: optionally to create a new keystore file run this comand in the apk folder
keytool -genkey -v -maxikioscos-android-release-key.keystore -alias maxikioscos-android -keyalg RSA -keysize 2048 -validity 10000

6.Sign the apk running the following command:
jarsigner -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore maxikioscos-android-release-key.keystore android-release-unsigned.apk maxikioscos-android

7.Just in case delete the maxikioscos.apk if it exists in the folder.

8.Optimize and generate the final apk running the command.
zipalign -v 4 android-release-unsigned.apk maxikioscos.apk

9.Save the maxikioscos.apk to the corresponding environment being deployed.