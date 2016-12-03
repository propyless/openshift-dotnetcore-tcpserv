# openshift-dotnetcore-tcpserv
TCP Server Demo App for Openshift Enterprise
This is a dotnet core demo app with out any external dependencies so that it can be tested in openshift container platform
that is in a locked down environment without external access.
Clone this repo to an internal repo which your openshift environment is able to communicate with.


__Example new-app command__

`oc new-app dotnet~https://github.com/propyless/openshift-dotnetcore-tcpserv.git --context-dir=test/tcp-serv`
