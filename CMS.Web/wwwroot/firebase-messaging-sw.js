importScripts('https://www.gstatic.com/firebasejs/9.1.1/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/9.1.1/firebase-messaging.js');

var config = {
    apiKey: "AIzaSyBS2R4GRT5JAcmH32sCqOFC_er8_o7sx8E",
    authDomain: "cmsweb-96ed9.firebaseapp.com",
    projectId: "cmsweb-96ed9",
    storageBucket: "cmsweb-96ed9.appspot.com",
    messagingSenderId: "1023004862665",
    appId: "1:1023004862665:web:76fd3b7147f8ad9c728518",
    measurementId: "G-0WQ18RZ9Q2"
};

firebase.initializeApp(config);

const messaging = firebase.messaging();

messaging.setBackgroundMessageHandler(function(payload) {
    //// Customize notification here
    var notificationTitle = 'My Titile';
    var notificationOptions = {
        body: payload.data.body
    };

    return self.registration.showNotification(notificationTitle,
        notificationOptions);
});