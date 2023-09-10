### Setup
$ ip addr show
```
3: eth0: <BROADCAST,MULTICAST,UP,LOWER_UP> mtu 1500 qdisc mq state UP group default qlen 1000
    link/ether 00:15:5d:00:01:1a brd ff:ff:ff:ff:ff:ff
    inet 172.20.48.1/20 brd 172.20.63.255 scope global eth0
       valid_lft forever preferred_lft forever
    inet6 fe80::215:5dff:fe00:11a/64 scope link
       valid_lft forever preferred_lft forever
```


You can use the `lsof` command to see which port Cassandra is listening on. Here's an example of how you can use this command:

```
sudo lsof -i -P -n | grep cassandra
```

This command lists all open network connections and filters the output to show only the connections associated with the `cassandra` process. The output should show the port number that Cassandra is listening on.

If you don't have the `lsof` command installed, you can install it using your package manager. For example, on Ubuntu or Debian-based systems, you can use the following command to install `lsof`:

```
sudo apt-get install lsof
```

Alternatively, you can check the `native_transport_port` setting in the `cassandra.yaml` configuration file to see which port Cassandra is configured to listen on. The default value for this setting is `9042`.


### Enter CQL mode
This will connect you to the default Cassandra instance running on your local machine.
```bash
cqlsh
```

If Cassandra is installed on a remote server or on a non-default host and port, you can specify the host and port using the -u and -p options. For example:
```bash
cqlsh -u <username> -p <password> <hostname> <port>
```

### Create Table
```sql
CREATE TABLE IF NOT EXISTS test_keyspace.animal (
    id UUID PRIMARY KEY,
    name text,
    bio text,
    petcolors text,
    sixdigitcode text,
    gender boolean,
    age double,
    dateofbirth timestamp,
    breedid text,
    petavatarid text,
    createdon timestamp,
    lastupdatedon timestamp
);
```

### Describe tables
#### List all the tables
```sql
describe tables
```
#### Describe a specific table
```sql
describe table animal
```

### Insert data
```sql
INSERT INTO test_keyspace.animal (id, age, bio, breedid, createdon, dateofbirth, gender, lastupdatedon, name, petavatarid, petcolors, sixdigitcode)
VALUES ('1', 3.5, 'Friendly dog', 'breed123', '2023-09-09T12:00:00Z', '2019-01-15T00:00:00Z', true, '2023-09-09T12:00:00Z', 'Fido', 'avatar123', 'brown,white', '123456');

INSERT INTO test_keyspace.animal (id, age, bio, breedid, createdon, dateofbirth, gender, lastupdatedon, name, petavatarid, petcolors, sixdigitcode)
VALUES ('2', 2.0, 'Playful cat', 'breed456', '2023-09-09T14:00:00Z', '2020-03-20T00:00:00Z', false, '2023-09-09T14:00:00Z', 'Whiskers', 'avatar789', 'gray', '987654');
```