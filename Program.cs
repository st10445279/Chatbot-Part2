using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace ChatbotPart1
{
    internal class Program
    {
        class CybersecurityChatBot
        {
            // Memory storage
            static string userName = "User";
            static string userTopic = "";
            static List<string> userInterests = new List<string>();

            // Random generator
            static Random random = new Random();

            // Dictionary for keyword-responses
            static Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>
            {
                ["password"] = new List<string>
                {
                    "Use strong passwords with a mix of letters, numbers, and symbols.",
                    "Never reuse passwords across multiple accounts.",
                    "Consider using a password manager to store and generate secure passwords.",
                    "Enable two-factor authentication (2FA) for extra security."
                },
                ["scam"] = new List<string>
                {
                    "Always verify the sender before sharing personal information.",
                    "If something seems too good to be true, it probably is.",
                    "Report suspicious messages to local authorities or platforms.",
                    "Avoid clicking on unsolicited links or downloading attachments from unknown sources."
                },
                ["privacy"] = new List<string>
                {
                    "Review privacy settings on your social media regularly.",
                    "Avoid oversharing personal details online.",
                    "Enable two-factor authentication wherever possible.",
                    "Use private browsing modes when accessing sensitive information."
                },
                ["phishing"] = new List<string>
                {
                    "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                    "Double-check the sender's email address for inconsistencies or misspellings.",
                    "Don’t click links in unsolicited emails—visit the company’s website directly instead.",
                    "Verify urgent requests by contacting the organisation directly via phone."
                },
                ["malware"] = new List<string>
                {
                    "Malware is malicious software designed to harm your system or steal data.",
                    "Install a reputable antivirus program and keep it updated.",
                    "Avoid downloading files from untrusted websites or email attachments.",
                    "Keep your operating system and applications up to date with security patches."
                },
                ["ransomware"] = new List<string>
                {
                    "Ransomware locks your files and demands payment to unlock them.",
                    "Regularly back up your important files to an external drive or cloud service.",
                    "Never pay the ransom—it doesn't guarantee recovery and encourages criminals.",
                    "Use anti-ransomware tools and keep your system patched."
                },
                ["2fa"] = new List<string>
                {
                    "Two-Factor Authentication adds an extra layer beyond just a password.",
                    "Use authenticator apps like Google Authenticator or Microsoft Authenticator.",
                    "Enable 2FA on all critical accounts such as banking, email, and social media.",
                    "Biometric authentication (like fingerprint or facial recognition) is also a valid form of 2FA."
                },
                ["firewall"] = new List<string>
                {
                    "A firewall acts as a barrier between your computer and potentially harmful traffic.",
                    "Make sure your operating system’s built-in firewall is enabled.",
                    "Consider using a hardware firewall for business networks.",
                    "Firewalls help block unauthorized access and detect suspicious activity."
                },
                ["encryption"] = new List<string>
                {
                    "Encryption scrambles data so only authorized users can read it.",
                    "Use end-to-end encrypted messaging apps like Signal or WhatsApp.",
                    "Encrypt sensitive files before storing them in the cloud.",
                    "HTTPS websites use encryption to protect your browsing data."
                },
                ["social engineering"] = new List<string>
                {
                    "Social engineering exploits human psychology rather than technical flaws.",
                    "Stay skeptical of unsolicited calls, emails, or messages asking for help.",
                    "Verify the identity of anyone requesting sensitive information.",
                    "Train yourself and others to recognize common manipulation tactics used by attackers."
                },
                ["data breach"] = new List<string>
                {
                    "A data breach occurs when sensitive data is accessed without authorization.",
                    "Check if your email has been involved in any breaches using services like HaveIBeenPwned.com.",
                    "Change passwords immediately if you suspect a breach.",
                    "Use unique passwords to prevent one breach from affecting multiple accounts."
                },
                ["vpn"] = new List<string>
                {
                    "A Virtual Private Network (VPN) encrypts your internet connection and hides your IP address.",
                    "Use a VPN when connecting to public Wi-Fi networks to protect your data.",
                    "Choose a trustworthy provider that does not log your activity.",
                    "VPNs are useful for protecting privacy but do not replace other security practices."
                }
            };

            // Phishing Tips - Random responses
            static List<string> phishingTips = new List<string>
            {
                "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                "Double-check the sender's email address for inconsistencies or misspellings.",
                "Don’t click links in unsolicited emails—visit the company’s website directly instead.",
                "Verify urgent requests by contacting the organisation directly via phone.",
                "Look out for poor grammar, odd formatting, or unexpected attachments.",
                "Hover over links before clicking to see where they really lead.",
                "Never provide login credentials through email or pop-up windows.",
                "Organizations like banks will never ask for your password via email.",
                "Phishing isn’t limited to email—be careful on SMS, social media, and voice calls too.",
                "Use browser extensions that warn about known phishing sites."
            };

            // Sentiment words
            static Dictionary<string, string> sentimentResponses = new Dictionary<string, string>
            {
                ["worried"] = "It's completely understandable to feel that way. Let me share some tips to help you stay safe.",
                ["frustrated"] = "Cybersecurity can feel overwhelming. Let's break it down together.",
                ["curious"] = "That's great to hear! Curiosity helps us stay informed and protected online.",
                ["scared"] = "Feeling uneasy is normal, especially with today’s threats. Knowledge is power, and I'm here to help.",
                ["confused"] = "No worries! Cybersecurity can be confusing at first. Let’s go over that again clearly.",
                ["tired"] = "It's okay to feel tired learning this. Take your time—we’re here to help you improve step by step.",
                ["angry"] = "It’s frustrating when scammers try to take advantage. You're doing the right thing by staying informed."
            };

            static void Main()
            {
                PlayVoiceGreeting();
                DisplayAsciiArtLogo();

                Console.Write("Please enter your name: ");
                userName = Console.ReadLine() ?? "User";

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nHello, {userName}! Welcome to the Cybersecurity Awareness Bot.");
                Console.ResetColor();

                ChatLoop();
            }

            static void PlayVoiceGreeting()
            {
                try
                {
                    SoundPlayer player = new SoundPlayer("welcome.wav");
                    player.PlaySync();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error playing greeting audio: {ex.Message}");
                    Console.ResetColor();
                }
            }

            static void DisplayAsciiArtLogo()
            {
                string logo = @"
  : ""
.---------------------------------------------------------------------------.
|            _                     _                             _          |
|  ___ _   _| |__   ___ _ __    __| |_   _ _ __   __ _ _ __ ___ (_) ___ ___ |
| / __| | | | '_ \ / _ | '__|  / _` | | | | '_ \ / _` | '_ ` _ \| |/ __/ __||
| \__ | |_| | |_) |  __| |    | (_| | |_| | | | | (_| | | | | | | | (__\__ \|
| |___|\__, |_.__/ \___|_|     \__,_|\__, |_| |_|\__,_|_| |_| |_|_|\___|___/|
|      |___/                         |___/                                  |
'---------------------------------------------------------------------------'
                ";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(logo);
                Console.ResetColor();
            }

            static void ChatLoop()
            {
                while (true)
                {
                    Console.Write("\nHow can I help you today? ");
                    string userInput = Console.ReadLine()?.ToLower().Trim();

                    if (string.IsNullOrEmpty(userInput))
                    {
                        Console.WriteLine("I didn't quite understand that. Could you rephrase?");
                        continue;
                    }

                    // Sentiment Detection
                    bool sentimentDetected = false;
                    foreach (var sentiment in sentimentResponses)
                    {
                        if (userInput.Contains(sentiment.Key))
                        {
                            Console.WriteLine(sentiment.Value);
                            sentimentDetected = true;
                            break;
                        }
                    }

                    if (sentimentDetected)
                        continue;

                    // Store user interest
                    if (userInput.Contains("i'm interested in") || userInput.Contains("my favorite topic is"))
                    {
                        var topic = userInput.Replace("i'm interested in", "")
                                             .Replace("my favorite topic is", "")
                                             .Trim();

                        if (!string.IsNullOrEmpty(topic))
                        {
                            userTopic = topic;
                            if (!userInterests.Contains(topic)) userInterests.Add(topic);

                            Console.WriteLine($"Great! I'll remember that you're interested in {topic}. It's a crucial part of staying safe online.");
                        }
                        continue;
                    }

                    // Store multiple interests
                    if (userInput.Contains("i like") || userInput.Contains("interested in"))
                    {
                        var topics = userInput.Replace("i like", "")
                                              .Replace("interested in", "")
                                              .Split(new[] { ',', ' ', ';', '.' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var topic in topics)
                        {
                            var cleanTopic = topic.Trim();
                            if (!userInterests.Contains(cleanTopic))
                                userInterests.Add(cleanTopic);
                        }

                        Console.WriteLine($"Got it! I'll remember your interests in: {string.Join(", ", userInterests)}");
                        continue;
                    }

                    // Keyword recognition
                    bool keywordMatched = false;
                    foreach (var keyword in keywordResponses.Keys)
                    {
                        if (userInput.Contains(keyword))
                        {
                            var responses = keywordResponses[keyword];
                            var response = responses[random.Next(responses.Count)];
                            Console.WriteLine(response);
                            keywordMatched = true;
                            break;
                        }
                    }

                    if (keywordMatched) continue;

                    // Phishing tip request
                    if (userInput.Contains("phishing tip"))
                    {
                        var tip = phishingTips[random.Next(phishingTips.Count)];
                        Console.WriteLine(tip);
                        continue;
                    }

                    // Follow-up based on remembered topic
                    if ((userInput.Contains("more") || userInput.Contains("tell me more")) && !string.IsNullOrEmpty(userTopic))
                    {
                        Console.WriteLine($"As someone interested in {userTopic}, here's a deeper look: Review your account security settings regularly and enable two-factor authentication.");
                        continue;
                    }

                    if (userInput.Contains("any advice") && userInterests.Count > 0)
                    {
                        Console.WriteLine($"Based on your interests in {string.Join(" and ", userInterests)}, I recommend reviewing your account settings and enabling two-factor authentication.");
                        continue;
                    }

                    // Default fallback
                    Console.WriteLine("Sorry, I didn't quite understand that. Could you please ask something else?");

                    // Ask to continue
                    Console.Write("\nDo you want to continue chatting? (yes/no): ");
                    string continueChat = Console.ReadLine()?.ToLower();
                    if (continueChat != "yes")
                    {
                        Console.WriteLine("Thank you for using the Cybersecurity Awareness Chatbot! Stay safe online.");
                        break;
                    }
                }
            }
        }
    }
}