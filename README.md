# what does the plugin do?
is it a plugin that when someone kills scp a broadcast comes or when the scp kills itself


```yml
scp_kill_msg:
  is_enabled: true
  debug: false
  suicide_message: |-
    <size=25><b>[Server Name] SCP-kill Message:</b>
    <color=#B72334>{role}</color> [{nickname}] has killed himself
    Reason: <color=#B72334>{reason}</color></size>
  kill_message: |-
    <size=25><b>[Server Name] SCP-kill Message:</b>
    <color=#B72334>{role}</color> [{nickname}] was killed by <color=#B72334>{killer}</color>
    Reason: <color=#B72334>{reason}</color></size>
  broadcast_duration: 10
```