# IPConversion
C# Program for Conversion(IPv4-IPv6)

//Input
1. First Input is IPV4 Address
2. Second Input is Subnet Mask Address

//Output
1. First Output is Binary Address of IPV4
2. Second Output is Binary Address of SubnetMask
3. Third Output is IPV4->IPV6(Compression)
4. Fourth Output is IPV4->IPV6(Expand)
5. Fifth Output is  Network Address
6. Sixth Output is CIDR Notation Address


**Sample Output:**
Enter IPV4 Adsress :
172.168.16.1
Enter SubNet Mask Adsress :
255.255.254.1
IPv4 Binary : 10101100.10101000.00010000.00000001
Subnet Mask Binary : 11111111.11111111.11111110.00000001
ipv4 -> ipv6(Compression) : ::2001:aca8:1001
ipv4 -> ipv6(Expand) : 0000:0000:0000:0000:0000:2001:aca8:1001
Network Address : 172.168.16.1
CIDR Notation : 172.168.16.1/24
