using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRental.Views.Shared
{
    public partial class TermsConditionsForm : Form
    {
        public bool Agreed { get; private set; } = false;

        public TermsConditionsForm()
        {
            InitializeComponent();
            LoadTerms();
        }

        private void LoadTerms()
        {
            richTextBox1.Text =
@"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        TERMS AND CONDITIONS — CAR RENTAL SYSTEM
        Effective Date: January 1, 2025 | Last Updated: March 2026
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Please read these Terms and Conditions carefully before renting a vehicle
from our Car Rental System. By proceeding with a rental, you confirm that
you have read, understood, and agreed to be bound by these terms.

────────────────────────────────────────────────────────────────────────
SECTION 1: ELIGIBILITY REQUIREMENTS
────────────────────────────────────────────────────────────────────────

1.1  AGE REQUIREMENT
     The minimum age to rent a vehicle is 21 years old. Renters between
     21–25 years old may be subject to a young driver surcharge fee.

1.2  VALID DRIVER'S LICENSE
     A valid, government-issued driver's license is required at the time
     of pickup. International renters must present an International
     Driving Permit (IDP) alongside their home country license.

1.3  IDENTITY VERIFICATION
     A valid government-issued ID (passport, national ID, or driver's
     license) must be presented upon vehicle pickup. Failure to provide
     valid identification will result in cancellation of the rental with
     no refund.

1.4  CREDIT/DEBIT CARD
     A valid credit or debit card is required for the security deposit.
     Prepaid cards are not accepted for deposit purposes.

────────────────────────────────────────────────────────────────────────
SECTION 2: RENTAL AGREEMENT & RESERVATIONS
────────────────────────────────────────────────────────────────────────

2.1  RESERVATION CONFIRMATION
     All reservations are subject to vehicle availability. A confirmed
     reservation does not guarantee a specific vehicle model, only the
     vehicle category booked.

2.2  RENTAL PERIOD
     The rental period begins at the time of vehicle pickup and ends
     at the agreed return time. Extensions must be requested at least
     3 hours before the scheduled return time and are subject to
     availability and additional charges.

2.3  EARLY RETURNS
     No refund will be issued for early vehicle returns unless explicitly
     stated in a special promotional offer.

2.4  AUTHORIZED DRIVERS
     Only the registered renter and explicitly authorized additional
     drivers (added at the time of rental for an additional fee) are
     permitted to operate the vehicle. Unauthorized drivers void all
     insurance coverage.

────────────────────────────────────────────────────────────────────────
SECTION 3: PAYMENT POLICY
────────────────────────────────────────────────────────────────────────

3.1  PAYMENT METHODS
     We accept cash, credit cards, and debit cards. Payments must be
     completed in full prior to vehicle release.

3.2  SECURITY DEPOSIT
     A refundable security deposit is required at pickup. The deposit
     amount varies by vehicle category:
       • Economy/Compact:   ₱ 2,000
       • Mid-size/SUV:      ₱ 5,000
       • Luxury/Premium:    ₱ 10,000
     The deposit is released within 3–5 business days after return,
     pending inspection.

3.3  ADDITIONAL FEES
     The following may incur additional charges:
       • Late return fee: ₱ 500 per hour beyond grace period (30 min)
       • Additional driver fee: ₱ 300 per day
       • GPS/Wi-Fi device: ₱ 200 per day
       • Child seat: ₱ 150 per day
       • Roadside assistance package: ₱ 400 per rental

3.4  FUEL POLICY
     Vehicles are provided with a full tank. The vehicle must be returned
     with a full tank. If not returned full, a refueling fee of ₱ 80/liter
     plus a ₱ 500 service charge will apply.

────────────────────────────────────────────────────────────────────────
SECTION 4: VEHICLE USE POLICY
────────────────────────────────────────────────────────────────────────

4.1  PROHIBITED USES
     The renter agrees NOT to use the vehicle for:
       • Any illegal activity or purpose
       • Transporting hazardous or illegal materials
       • Towing or pushing any other vehicle or trailer
       • Off-road driving unless in a designated off-road vehicle
       • Racing, speed tests, or driving competitions
       • Transporting more passengers than the vehicle's rated capacity

4.2  SMOKING POLICY
     Smoking inside the vehicle is strictly prohibited. A cleaning fee
     of ₱ 2,500 will be charged if evidence of smoking is found.

4.3  PET POLICY
     Pets are not allowed inside the vehicle unless a pet-friendly
     vehicle has been specifically requested and approved. Unauthorized
     pets will result in a ₱ 1,500 cleaning fee.

4.4  MILEAGE POLICY
     Standard rentals include unlimited mileage within the country.
     Cross-border travel requires prior written approval and may incur
     additional fees and insurance requirements.

4.5  VEHICLE MODIFICATIONS
     No modifications, alterations, or additions to the vehicle are
     permitted under any circumstances.

────────────────────────────────────────────────────────────────────────
SECTION 5: INSURANCE & LIABILITY
────────────────────────────────────────────────────────────────────────

5.1  BASIC INSURANCE
     All rentals include basic Collision Damage Waiver (CDW) and Third
     Party Liability (TPL) coverage as required by law.

5.2  RENTER'S LIABILITY
     The renter is liable for all damages not covered by the included
     insurance, including but not limited to:
       • Damages caused by reckless or negligent driving
       • Damages caused by driving under the influence (DUI)
       • Damages from unauthorized use or unauthorized driver
       • Theft due to keys left in the vehicle

5.3  ADDITIONAL INSURANCE OPTIONS
     Renters may purchase additional coverage:
       • Personal Accident Insurance (PAI)
       • Super Collision Damage Waiver (SCDW) — reduces deductible to ₱0
       • Extended Roadside Assistance

5.4  ACCIDENTS & INCIDENTS
     In the event of an accident, the renter must:
       a) Immediately notify local authorities (call 911)
       b) Do not move the vehicle unless required for safety
       c) Obtain a police report reference number
       d) Notify our office within 24 hours
       e) Provide full cooperation for insurance claims

────────────────────────────────────────────────────────────────────────
SECTION 6: VEHICLE RETURN & DAMAGE POLICY
────────────────────────────────────────────────────────────────────────

6.1  RETURN CONDITION
     The vehicle must be returned in the same condition it was rented,
     subject to normal wear and tear. A thorough inspection will be
     conducted upon return.

6.2  DAMAGE ASSESSMENT FEES
     Damage charges may include:
       • Scratch repair:          ₱ 1,500 – ₱ 5,000
       • Dented bumper:           ₱ 3,000 – ₱ 8,000
       • Broken mirror:           ₱ 2,000 – ₱ 4,000
       • Flat tire replacement:   ₱ 2,500 – ₱ 6,000
       • Windshield crack:        ₱ 4,000 – ₱ 12,000
       • Broken headlight:        ₱ 3,500 – ₱ 7,000
       • Stained upholstery:      ₱ 1,500 – ₱ 3,000

6.3  TOTAL LOSS
     In the event of total loss or theft of the vehicle, the renter is
     liable for the full replacement value of the vehicle as determined
     by the company, minus any applicable insurance coverage.

────────────────────────────────────────────────────────────────────────
SECTION 7: CANCELLATION POLICY
────────────────────────────────────────────────────────────────────────

7.1  CANCELLATION BY RENTER
       • 48+ hours before pickup:   Full refund
       • 24–48 hours before pickup: 50% refund
       • Less than 24 hours:        No refund
       • No-show:                   Full charge + ₱ 500 no-show fee

7.2  CANCELLATION BY COMPANY
     We reserve the right to cancel a reservation due to:
       • Vehicle unavailability due to unforeseen circumstances
       • Safety or maintenance concerns
       • Failure of renter to meet eligibility requirements
     In such cases, a full refund will be issued.

────────────────────────────────────────────────────────────────────────
SECTION 8: PRIVACY & DATA
────────────────────────────────────────────────────────────────────────

8.1  DATA COLLECTION
     We collect personal information for the purpose of processing
     rentals, verifying identity, and complying with legal obligations.
     Your data will not be sold to third parties.

8.2  DATA RETENTION
     Rental records and personal data are retained for a minimum of
     5 years in compliance with applicable laws.

────────────────────────────────────────────────────────────────────────
SECTION 9: GOVERNING LAW
────────────────────────────────────────────────────────────────────────

9.1  These Terms and Conditions are governed by the laws of the
     Republic of the Philippines. Any disputes arising from this
     agreement shall be resolved through arbitration or in the
     appropriate courts of the Philippines.

9.2  If any provision of these Terms is found to be invalid or
     unenforceable, the remaining provisions shall continue in
     full force and effect.

────────────────────────────────────────────────────────────────────────
SECTION 10: AMENDMENTS
────────────────────────────────────────────────────────────────────────

10.1 The company reserves the right to modify these Terms and Conditions
     at any time. Renters will be notified of significant changes.
     Continued use of our services after notification constitutes
     acceptance of the updated terms.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
     By checking the box below, you confirm that you have read,
     understood, and agree to all Terms and Conditions stated above.
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
        }

        private void chkAgree_CheckedChanged(object sender, EventArgs e)
        {
            btnAgree.Enabled = chkAgree.Checked;
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            Agreed = true;
            MessageBox.Show("Thank you for agreeing to our Terms and Conditions.",
                "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            Agreed = false;
            DialogResult result = MessageBox.Show(
                "If you decline, you will not be able to proceed with the rental.\nAre you sure you want to decline?",
                "Decline Terms", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}