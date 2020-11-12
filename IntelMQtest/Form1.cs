using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelMQtest
{
    public partial class Form1 : Form
    {
        static BindingList<string> bindingItemList = new BindingList<string>();
        static Dictionary<String, String> currentfields = new Dictionary<string, string>();
        // key, description, length, regex, type
        static String[] classification_types = { "application-compromise", "backdoor", "blacklist", "brute-force", "burglary", "c2server", "compromised", "copyright", "data-loss", "ddos", "ddos-amplifier", "defacement", "dga domain", "dos", "dropzone", "exploit", "harmful-speech", "ids-alert", "infected-system", "information-disclosure", "leak", "malware", "malware-configuration", "malware-distribution", "masquerade", "other", "outage", "phishing", "potentially-unwanted-accessible", "privileged-account-compromise", "proxy", "ransomware", "sabotage", "scanner", "sniffing", "social-engineering", "spam", "test", "tor", "Unauthorised-information-access", "Unauthorised-information-modification", "unauthorized-command", "unauthorized-login", "unauthorized-use-of-resources", "unknown", "unprivileged-account-compromise", "violence", "vulnerable client", "vulnerable service", "vulnerable-system", "weak-crypto" };
        static String[] classification_taxonomies = { "abusive content", "availability", "fraud", "information content security", "information gathering", "intrusion attempts", "intrusions", "malicious code", "other", "test", "vulnerable" };
        static String[,] fieldnames = {
{"classification.identifier", "The lowercase identifier defines the actual software or service (e.g. 'heartbleed' or 'ntp_version') or standardized malware name (e.g. 'zeus'). Note that you MAY overwrite this field during processing for your individual setup. This field is not standardized across IntelMQ setups/users.", "", "", "String"},
{"classification.taxonomy", "We recognize the need for the CSIRT teams to apply a static (incident) taxonomy to abuse data. With this goal in mind the type IOC will serve as a basis for this activity. Each value of the dynamic type mapping translates to a an element in the static taxonomy. The European CSIRT teams for example have decided to apply the eCSIRT.net incident classification. The value of the taxonomy key is thus a derivative of the dynamic type above. For more information about check [ENISA taxonomies](http://www.enisa.europa.eu/activities/cert/support/incident-management/browsable/incident-handling-process/incident-taxonomy/existing-taxonomies).", "100", "", "LowercaseString"},
{"classification.type", "The abuse type IOC is one of the most crucial pieces of information for any given abuse event. The main idea of dynamic typing is to keep our ontology flexible, since we need to evolve with the evolving threatscape of abuse data. In contrast with the static taxonomy below, the dynamic typing is used to perform business decisions in the abuse handling pipeline. Furthermore, the value data set should be kept as minimal as possible to avoid \u201ctype explosion\u201d, which in turn dilutes the business value of the dynamic typing. In general, we normally have two types of abuse type IOC: ones referring to a compromised resource or ones referring to pieces of the criminal infrastructure, such as a command and control servers for example.", "", "", "ClassificationType"},
{"comment", "Free text commentary about the abuse event inserted by an analyst.", "", "", "String"},
{"destination.abuse_contact", "Abuse contact for destination address. A comma separated list.", "", "", "LowercaseString"},
{"destination.account", "An account name or email address, which has been identified to relate to the destination of an abuse event.", "", "", "String"},
{"destination.allocated", "Allocation date corresponding to BGP prefix.", "", "", "DateTime"},
{"destination.as_name", "The autonomous system name to which the connection headed.", "", "", "String"},
{"destination.asn", "The autonomous system number to which the connection headed.", "", "", "ASN"},
{"destination.domain_suffix", "The suffix of the domain from the public suffix list.", "", "", "FQDN"},
{"destination.fqdn", "A DNS name related to the host from which the connection originated. DNS allows even binary data in DNS, so we have to allow everything. A final point is stripped, string is converted to lower case characters.", "", "^.*[^\\.]$", "FQDN"},
{"destination.geolocation.cc", "Country-Code according to ISO3166-1 alpha-2 for the destination IP.", "2", "^[a-zA-Z0-9]{2}$", "UppercaseString"},
{"destination.geolocation.city", "Some geolocation services refer to city-level geolocation.", "", "", "String"},
{"destination.geolocation.country", "The country name derived from the ISO3166 country code (assigned to cc field).", "", "", "String"},
{"destination.geolocation.latitude", "Latitude coordinates derived from a geolocation service, such as MaxMind geoip db.", "", "", "Float"},
{"destination.geolocation.longitude", "Longitude coordinates derived from a geolocation service, such as MaxMind geoip db.", "", "", "Float"},
{"destination.geolocation.region", "Some geolocation services refer to region-level geolocation.", "", "", "String"},
{"destination.geolocation.state", "Some geolocation services refer to state-level geolocation.", "", "", "String"},
{"destination.ip", "The IP which is the target of the observed connections.", "", "", "IPAddress"},
{"destination.local_hostname", "Some sources report a internal hostname within a NAT related to the name configured for a compromized system", "", "", "String"},
{"destination.local_ip", "Some sources report a internal (NATed) IP address related a compromized system. N.B. RFC1918 IPs are OK here.", "", "", "IPAddress"},
{"destination.network", "CIDR for an autonomous system. Also known as BGP prefix. If multiple values are possible, select the most specific.", "", "", "IPNetwork"},
{"destination.port", "The port to which the connection headed.", "", "", "Integer"},
{"destination.registry", "The IP registry a given ip address is allocated by.", "7", "", "Registry"},
{"destination.reverse_dns", "Reverse DNS name acquired through a reverse DNS query on an IP address. N.B. Record types other than PTR records may also appear in the reverse DNS tree. Furthermore, unfortunately, there is no rule prohibiting people from writing anything in a PTR record. Even JavaScript will work. A final point is stripped, string is converted to lower case characters.", "", "^.*[^\\.]$", "FQDN"},
{"destination.tor_node", "If the destination IP was a known tor node.", "", "", "Boolean"},
{"destination.url", "A URL denotes on IOC, which refers to a malicious resource, whose interpretation is defined by the abuse type. A URL with the abuse type phishing refers to a phishing resource.", "", "", "URL"},
{"destination.urlpath", "The path portion of an HTTP or related network request.", "", "", "String"},
{"event_description.target", "Some sources denominate the target (organization) of a an attack.", "", "", "String"},
{"event_description.text", "A free-form textual description of an abuse event.", "", "", "String"},
{"event_description.url", "A description URL is a link to a further description of the the abuse event in question.", "", "", "URL"},
{"event_hash", "Computed event hash with specific keys and values that identify a unique event. At present, the hash should default to using the SHA1 function. Please note that for an event hash to be able to match more than one event (deduplication) the receiver of an event should calculate it based on a minimal set of keys and values present in the event. Using for example the observation time in the calculation will most likely render the checksum useless for deduplication purposes.", "40", "^[A-F0-9./]+$", "UppercaseString"},
{"extra", "All anecdotal information, which cannot be parsed into the data harmonization elements. E.g. os.name, os.version, etc.  **Note**: this is only intended for mapping any fields which can not map naturally into the data harmonization. It is not intended for extending the data harmonization with your own fields.", "", "", "JSONDict"},
{"feed.accuracy", "A float between 0 and 100 that represents how accurate the data in the feed is", "", "", "Accuracy"},
{"feed.code", "Code name for the feed, e.g. DFGS, HSDAG etc.", "100", "", "String"},
{"feed.documentation", "A URL or hint where to find the documentation of this feed.", "", "", "String"},
{"feed.name", "Name for the feed, usually found in collector bot configuration.", "", "", "String"},
{"feed.provider", "Name for the provider of the feed, usually found in collector bot configuration.", "", "", "String"},
{"feed.url", "The URL of a given abuse feed, where applicable", "", "", "URL"},
{"malware.hash.md5", "A string depicting an MD5 checksum for a file, be it a malware sample for example.", "200", "^[ -~]+$", "String"},
{"malware.hash.sha1", "A string depicting a SHA1 checksum for a file, be it a malware sample for example.", "200", "^[ -~]+$", "String"},
{"malware.hash.sha256", "A string depicting a SHA256 checksum for a file, be it a malware sample for example.", "200", "^[ -~]+$", "String"},
{"malware.name", "The malware name in lower case.", "", "^[ -~]+$", "LowercaseString"},
{"malware.version", "A version string for an identified artifact generation, e.g. a crime-ware kit.", "", "^[ -~]+$", "String"},
{"misp.attribute_uuid", "MISP - Malware Information Sharing Platform & Threat Sharing UUID of an attribute.", "36", "^[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}$", "LowercaseString"},
{"misp.event_uuid", "MISP - Malware Information Sharing Platform & Threat Sharing UUID.", "36", "^[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[0-9a-z]{12}$", "LowercaseString"},
{"output", "Event data converted into foreign format, intended to be exported by output plugin.", "", "", "JSON"},
{"protocol.application", "e.g. vnc, ssh, sip, irc, http or smtp.", "100", "^[ -~]+$", "LowercaseString"},
{"protocol.transport", "e.g. tcp, udp, icmp.", "11", "^(ip|icmp|igmp|ggp|ipencap|st2|tcp|cbt|egp|igp|bbn-rcc|nvp(-ii)?|pup|argus|emcon|xnet|chaos|udp|mux|dcn|hmp|prm|xns-idp|trunk-1|trunk-2|leaf-1|leaf-2|rdp|irtp|iso-tp4|netblt|mfe-nsp|merit-inp|sep|3pc|idpr|xtp|ddp|idpr-cmtp|tp\\+\\+|il|ipv6|sdrp|ipv6-route|ipv6-frag|idrp|rsvp|gre|mhrp|bna|esp|ah|i-nlsp|swipe|narp|mobile|tlsp|skip|ipv6-icmp|ipv6-nonxt|ipv6-opts|cftp|sat-expak|kryptolan|rvd|ippc|sat-mon|visa|ipcv|cpnx|cphb|wsn|pvp|br-sat-mon|sun-nd|wb-mon|wb-expak|iso-ip|vmtp|secure-vmtp|vines|ttp|nsfnet-igp|dgp|tcf|eigrp|ospf|sprite-rpc|larp|mtp|ax.25|ipip|micp|scc-sp|etherip|encap|gmtp|ifmp|pnni|pim|aris|scps|qnx|a/n|ipcomp|snp|compaq-peer|ipx-in-ip|vrrp|pgm|l2tp|ddx|iatp|st|srp|uti|smp|sm|ptp|isis|fire|crtp|crdup|sscopmce|iplt|sps|pipe|sctp|fc|divert)$", "LowercaseString"},
{"raw", "The original line of the event from encoded in base64.", "", "", "Base64"},
{"rtir_id", "Request Tracker Incident Response ticket id.", "", "", "Integer"},
{"screenshot_url", "Some source may report URLs related to a an image generated of a resource without any metadata. Or an URL pointing to resource, which has been rendered into a webshot, e.g. a PNG image and the relevant metadata related to its retrieval/generation.", "", "", "URL"},
{"source.abuse_contact", "Abuse contact for source address. A comma separated list.", "", "", "LowercaseString"},
{"source.account", "An account name or email address, which has been identified to relate to the source of an abuse event.", "", "", "String"},
{"source.allocated", "Allocation date corresponding to BGP prefix.", "", "", "DateTime"},
{"source.as_name", "The autonomous system name from which the connection originated.", "", "", "String"},
{"source.asn", "The autonomous system number from which originated the connection.", "", "", "ASN"},
{"source.domain_suffix", "The suffix of the domain from the public suffix list.", "", "", "FQDN"},
{"source.fqdn", "A DNS name related to the host from which the connection originated. DNS allows even binary data in DNS, so we have to allow everything. A final point is stripped, string is converted to lower case characters.", "", "^.*[^\\.]$", "FQDN"},
{"source.geolocation.cc", "Country-Code according to ISO3166-1 alpha-2 for the source IP.", "2", "^[a-zA-Z0-9]{2}$", "UppercaseString"},
{"source.geolocation.city", "Some geolocation services refer to city-level geolocation.", "", "", "String"},
{"source.geolocation.country", "The country name derived from the ISO3166 country code (assigned to cc field).", "", "", "String"},
{"source.geolocation.cymru_cc", "The country code denoted for the ip by the Team Cymru asn to ip mapping service.", "2", "^[a-zA-Z0-9]{2}$", "UppercaseString"},
{"source.geolocation.geoip_cc", "MaxMind Country Code (ISO3166-1 alpha-2).", "2", "^[a-zA-Z0-9]{2}$", "UppercaseString"},
{"source.geolocation.latitude", "Latitude coordinates derived from a geolocation service, such as MaxMind geoip db.", "", "", "Float"},
{"source.geolocation.longitude", "Longitude coordinates derived from a geolocation service, such as MaxMind geoip db.", "", "", "Float"},
{"source.geolocation.region", "Some geolocation services refer to region-level geolocation.", "", "", "String"},
{"source.geolocation.state", "Some geolocation services refer to state-level geolocation.", "", "", "String"},
{"source.ip", "The ip observed to initiate the connection", "", "", "IPAddress"},
{"source.local_hostname", "Some sources report a internal hostname within a NAT related to the name configured for a compromised system", "", "", "String"},
{"source.local_ip", "Some sources report a internal (NATed) IP address related a compromised system. N.B. RFC1918 IPs are OK here.", "", "", "IPAddress"},
{"source.network", "CIDR for an autonomous system. Also known as BGP prefix. If multiple values are possible, select the most specific.", "", "", "IPNetwork"},
{"source.port", "The port from which the connection originated.", "5", "", "Integer"},
{"source.registry", "The IP registry a given ip address is allocated by.", "7", "", "Registry"},
{"source.reverse_dns", "Reverse DNS name acquired through a reverse DNS query on an IP address. N.B. Record types other than PTR records may also appear in the reverse DNS tree. Furthermore, unfortunately, there is no rule prohibiting people from writing anything in a PTR record. Even JavaScript will work. A final point is stripped, string is converted to lower case characters.", "", "^.*[^\\.]$", "FQDN"},
{"source.tor_node", "If the source IP was a known tor node.", "", "", "Boolean"},
{"source.url", "A URL denotes an IOC, which refers to a malicious resource, whose interpretation is defined by the abuse type. A URL with the abuse type phishing refers to a phishing resource.", "", "", "URL"},
{"source.urlpath", "The path portion of an HTTP or related network request.", "", "", "String"},
{"status", "Status of the malicious resource (phishing, dropzone, etc), e.g. online, offline.", "", "", "String"},
{"time.observation", "The time the collector of the local instance processed (observed) the event.", "", "", "DateTime"},
{"time.source", "The time of occurence of the event as reported the feed (source).", "", "", "DateTime"},
{"tlp", "Traffic Light Protocol level of the event.", "", "", "TLP"}
        };

        public Form1()
        {
            //currentfields.Add("feed", "n/a");
            //bindingItemList.Add("feed");
            currentfields.Add("classification.type", "");
            bindingItemList.Add("classification.type");
            currentfields.Add("classification.taxonomy", "");
            bindingItemList.Add("classification.taxonomy");
            currentfields.Add("source.ip", "");
            bindingItemList.Add("source.ip");

            InitializeComponent();

            listBox1.DataSource = bindingItemList;
            //listBox1.DataSource = new BindingSource(bindingItemList, null);
            //listBox1.DisplayMember = "Key";
            //listBox1.ValueMember = "Value";

            for (int i=0; i<fieldnames.GetLength(0); i++)
            {
                int index = cb_addfield.Items.Add(fieldnames[i,0]);
            }
            
        }

        private void button_getcurl_Click(object sender, EventArgs e)
        {
            // LINUX CURL: curl -X POST http://... -H '...' --data '{"abc": "def"}'
            // WINDOWS CURL: curl -X POST http://127.0.0.1:5000/intelmq/push -H "Content-Type: application/json" --data "{\"source.ip\": \"127.0.0.222\", \"classification.type\": \"backdoor\"}"
            
            String header = " -H \"Content - Type: application / json\"";
            String data_begin = " --data \"{";
            String data = "";
            String data_end = "}\"";

            foreach(KeyValuePair<String, String> tmp in currentfields)
            {
                data += "\\\"" + tmp.Key + "\\\": \\\"" + tmp.Value + "\\\",";
            }
            data = data.Substring(0, data.Length - 1);

            data = data_begin + data + data_end;
            String result = "curl -X POST " + tb_ip.Text + header + data;

            tb_result.Text = result;
        }

        private void button_addcurrentfield_Click(object sender, EventArgs e)
        {
            try
            {
                currentfields.Add(cb_addfield.Text, "");
                bindingItemList.Add(cb_addfield.Text);
            }
            catch (Exception)
            { }
        }

        private void button_removecurrentfield_Click(object sender, EventArgs e)
        {
            try
            {
                currentfields.Remove(cb_addfield.Text);
                bindingItemList.Remove(cb_addfield.Text);
            }
            catch (Exception)
            { }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tmp = "";
            try
            {
                currentfields.TryGetValue(listBox1.Text, out tmp);
            }
            catch (Exception)
            { }
            //tb_currentfieldvalue.Text = tmp;
            cb_currentfieldvalue.Text = tmp;

            for (int i = 0; i < fieldnames.GetLength(0); i++)
            {
                if (fieldnames[i, 0] == listBox1.Text)
                {
                    tb_help.Text = "description: " + fieldnames[i,1] + "\nlength: " + fieldnames[i, 2] + "\nregex: " + fieldnames[i, 3] + "\ntype: " + fieldnames[i, 4] + "\n";
                }
            }

            cb_currentfieldvalue.Items.Clear();

            if (listBox1.Text == "classification.type")
            {
                foreach (String tmpstr in classification_types)
                {
                    cb_currentfieldvalue.Items.Add(tmpstr);
                }
            }

            if (listBox1.Text == "classification.taxonomy")
            {
                foreach (String tmpstr in classification_taxonomies)
                {
                    cb_currentfieldvalue.Items.Add(tmpstr);
                }
            }

        }

        private void button_applyfieldchange_Click(object sender, EventArgs e)
        {
            try
            {
                currentfields.Remove(listBox1.Text);
            }
            catch (Exception)
            { }
            //currentfields.Add(listBox1.Text, tb_currentfieldvalue.Text);
            currentfields.Add(listBox1.Text, cb_currentfieldvalue.Text);
        }

        private void button_exechttpreq_Click(object sender, EventArgs e)
        {
            MyWebClient mwc = new MyWebClient();
            string URI = "http://www.myurl.com/post.php";
            string myParameters = "param1=value1&param2=value2&param3=value3";
            mwc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HtmlResult = mwc.UploadString(URI, myParameters);
            //mwc.DownloadString("");
        }
    }
}
