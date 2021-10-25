using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestReach.Exam.Data.Migrations
{
    public partial class AddInitialExamData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { "EX202001", new DateTime(2021, 10, 25, 0, 35, 49, 683, DateTimeKind.Local).AddTicks(1948), "Exam 1" },
                    { "EX202002", new DateTime(2021, 10, 25, 0, 35, 49, 683, DateTimeKind.Local).AddTicks(7712), "Exam 2" },
                    { "EX202003", new DateTime(2021, 10, 25, 0, 35, 49, 683, DateTimeKind.Local).AddTicks(7722), "Exam 3" },
                    { "EX202004", new DateTime(2021, 10, 25, 0, 35, 49, 683, DateTimeKind.Local).AddTicks(7724), "Exam 4" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "ExamId", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("04303027-7a5e-4ff1-a792-2ad43070ce93"), "A", "EX202001", 1 },
                    { new Guid("22248d38-3267-4132-b2f6-c7c671504839"), "A", "EX202003", 5 },
                    { new Guid("a3f12cb7-1844-4b76-b750-542e3ca8fa61"), "C", "EX202003", 6 },
                    { new Guid("ec6d68f3-5d35-478a-87b3-fc5f667b27f6"), "D", "EX202003", 7 },
                    { new Guid("257fbd47-3033-419c-b4dc-7f7387d4afd8"), "E", "EX202003", 8 },
                    { new Guid("d4a1f573-d278-45c5-8811-97b352b294ed"), "A", "EX202003", 9 },
                    { new Guid("09727a0f-2d4b-435c-ba17-665878c1c419"), "A", "EX202003", 10 },
                    { new Guid("aab3cee1-71af-4598-9e11-ef7f19caeadd"), "E", "EX202003", 11 },
                    { new Guid("faedf7e4-5c5b-4205-b503-7eed61d88cc0"), "C", "EX202003", 12 },
                    { new Guid("18c1ba39-faa4-49a4-98e6-32c1afe1b112"), "B", "EX202003", 13 },
                    { new Guid("e659c85d-9472-41a7-a98f-b505155ba3a8"), "A", "EX202003", 14 },
                    { new Guid("9987532c-0df2-4a25-9755-eee05740ed13"), "B", "EX202003", 15 },
                    { new Guid("3d39dd09-f6e5-4d79-a7f8-e04cf52b3d94"), "C", "EX202003", 16 },
                    { new Guid("1f91591e-0a70-4d46-8a41-53f3f0b953a1"), "E", "EX202003", 4 },
                    { new Guid("8abd0874-567a-4027-8e23-e8d27f7f8c15"), "A", "EX202003", 17 },
                    { new Guid("b493caa7-c4da-45bc-903c-812839af7678"), "B", "EX202003", 19 },
                    { new Guid("768fd656-3496-4ba0-8924-e7839a9f67ce"), "D", "EX202003", 20 },
                    { new Guid("879dacbf-ff69-4d3a-8769-2e341087f2bb"), "E", "EX202004", 1 },
                    { new Guid("9b307e7b-7fb4-4e8c-aca7-1d9e6ed5f2d2"), "A", "EX202004", 2 },
                    { new Guid("313bd5af-0ca5-45ae-9ec5-9b34d42c2fa4"), "C", "EX202004", 3 },
                    { new Guid("ebda3531-5261-48ea-a8bb-46c2166e0e96"), "D", "EX202004", 4 },
                    { new Guid("c976e399-c219-445c-9bcf-7fbee1b8f53f"), "E", "EX202004", 5 },
                    { new Guid("ee1330c0-db69-4eb3-ab5f-87be43636018"), "A", "EX202004", 6 },
                    { new Guid("b725149d-5635-4ffc-b466-efe4400408c4"), "A", "EX202004", 7 },
                    { new Guid("d1acadc7-2085-433c-8ed7-a58893d26e47"), "E", "EX202004", 8 },
                    { new Guid("6e486c0c-2b55-45b7-b73e-663fdac42176"), "C", "EX202004", 9 },
                    { new Guid("e93dc31b-c9c0-4076-a263-9dfaccdc6c5d"), "B", "EX202004", 10 },
                    { new Guid("54146f0e-db7e-4d4e-84aa-5b4f2bf1c425"), "B", "EX202003", 18 },
                    { new Guid("e16d0d52-0f76-404a-8823-fe6dcf96d272"), "A", "EX202004", 11 },
                    { new Guid("8a5151ea-88ad-42f5-b18f-9faeb4e1d778"), "E", "EX202003", 3 },
                    { new Guid("ed8cc69e-2825-49fb-b9fd-ddb26b3c3ef4"), "B", "EX202003", 1 },
                    { new Guid("5f1e8b37-4699-4cea-b1c8-173da1dfb6ee"), "C", "EX202001", 2 },
                    { new Guid("5719bf76-6bd4-40db-b6b1-cc257bdb1256"), "C", "EX202001", 3 },
                    { new Guid("bb087f75-93e3-4de8-a50b-b79b63ef224a"), "A", "EX202001", 4 },
                    { new Guid("3a12e8ff-4bb4-4464-b987-a8640ac066db"), "B", "EX202001", 5 },
                    { new Guid("b20a7903-7c08-444b-b1d3-58abb454c6f0"), "B", "EX202001", 6 },
                    { new Guid("d32e8a1b-17ac-46d4-ac5e-306374f752af"), "C", "EX202001", 7 },
                    { new Guid("4a5f8d24-4fc1-4e33-9e3d-6b8e52f6c345"), "A", "EX202001", 8 },
                    { new Guid("bd2c9dce-7c1a-430e-818a-141dd8fcfc3a"), "D", "EX202001", 9 },
                    { new Guid("e7ece826-5e40-4175-869d-c85a70ad866f"), "A", "EX202001", 10 },
                    { new Guid("af6d75d3-e287-4f5b-9292-e40fd3847933"), "B", "EX202002", 1 },
                    { new Guid("b47e9a9a-10b2-41e3-9185-1a7e740ef64e"), "D", "EX202002", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "ExamId", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("e1b10568-cc3b-4a1f-8bf7-ad5477fbe422"), "C", "EX202002", 3 },
                    { new Guid("f220cc33-9c71-4d26-ba27-5801a50405ce"), "C", "EX202003", 2 },
                    { new Guid("1b702dc4-fc22-4379-9628-4a2a49adca07"), "C", "EX202002", 4 },
                    { new Guid("71b11817-4287-4f88-b3ce-1490c59c3457"), "D", "EX202002", 6 },
                    { new Guid("3ce99c72-9b75-472f-839d-be773c526284"), "E", "EX202002", 7 },
                    { new Guid("24b175d4-296b-41ba-8f56-553c4706fc3c"), "E", "EX202002", 8 },
                    { new Guid("d49573ed-c32c-4fea-ad99-e737c86204d0"), "C", "EX202002", 9 },
                    { new Guid("db8f1e58-7d66-4d82-a4a0-7ba06e0d5407"), "A", "EX202002", 10 },
                    { new Guid("3006a35f-03b1-4ffb-9406-73eac9b9f509"), "E", "EX202002", 11 },
                    { new Guid("ad5b5c85-c1ef-439e-b375-a976e093a424"), "C", "EX202002", 12 },
                    { new Guid("39b89e8d-ed1d-4722-9264-22658df29fa4"), "D", "EX202002", 13 },
                    { new Guid("ffa55825-3886-4501-a2e1-79d7c28bf206"), "E", "EX202002", 14 },
                    { new Guid("9000f4bb-15dc-42de-b2fb-fb5b030b24c5"), "A", "EX202002", 15 },
                    { new Guid("52b0970e-61cd-4a48-a119-1110ae365f6f"), "B", "EX202002", 16 },
                    { new Guid("ec653cb5-3de4-435f-93eb-0b9bfd93a3f7"), "D", "EX202002", 17 },
                    { new Guid("6c68197a-13de-4231-a0ab-25e3bc2645eb"), "A", "EX202002", 5 },
                    { new Guid("47e447d4-8cc8-4d52-960a-cb8da8474c9e"), "B", "EX202004", 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("04303027-7a5e-4ff1-a792-2ad43070ce93"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("09727a0f-2d4b-435c-ba17-665878c1c419"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("18c1ba39-faa4-49a4-98e6-32c1afe1b112"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("1b702dc4-fc22-4379-9628-4a2a49adca07"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("1f91591e-0a70-4d46-8a41-53f3f0b953a1"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("22248d38-3267-4132-b2f6-c7c671504839"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("24b175d4-296b-41ba-8f56-553c4706fc3c"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("257fbd47-3033-419c-b4dc-7f7387d4afd8"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("3006a35f-03b1-4ffb-9406-73eac9b9f509"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("313bd5af-0ca5-45ae-9ec5-9b34d42c2fa4"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("39b89e8d-ed1d-4722-9264-22658df29fa4"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("3a12e8ff-4bb4-4464-b987-a8640ac066db"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("3ce99c72-9b75-472f-839d-be773c526284"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("3d39dd09-f6e5-4d79-a7f8-e04cf52b3d94"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("47e447d4-8cc8-4d52-960a-cb8da8474c9e"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("4a5f8d24-4fc1-4e33-9e3d-6b8e52f6c345"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("52b0970e-61cd-4a48-a119-1110ae365f6f"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("54146f0e-db7e-4d4e-84aa-5b4f2bf1c425"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("5719bf76-6bd4-40db-b6b1-cc257bdb1256"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("5f1e8b37-4699-4cea-b1c8-173da1dfb6ee"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("6c68197a-13de-4231-a0ab-25e3bc2645eb"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("6e486c0c-2b55-45b7-b73e-663fdac42176"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("71b11817-4287-4f88-b3ce-1490c59c3457"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("768fd656-3496-4ba0-8924-e7839a9f67ce"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("879dacbf-ff69-4d3a-8769-2e341087f2bb"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("8a5151ea-88ad-42f5-b18f-9faeb4e1d778"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("8abd0874-567a-4027-8e23-e8d27f7f8c15"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9000f4bb-15dc-42de-b2fb-fb5b030b24c5"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9987532c-0df2-4a25-9755-eee05740ed13"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("9b307e7b-7fb4-4e8c-aca7-1d9e6ed5f2d2"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("a3f12cb7-1844-4b76-b750-542e3ca8fa61"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("aab3cee1-71af-4598-9e11-ef7f19caeadd"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("ad5b5c85-c1ef-439e-b375-a976e093a424"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("af6d75d3-e287-4f5b-9292-e40fd3847933"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("b20a7903-7c08-444b-b1d3-58abb454c6f0"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("b47e9a9a-10b2-41e3-9185-1a7e740ef64e"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("b493caa7-c4da-45bc-903c-812839af7678"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("b725149d-5635-4ffc-b466-efe4400408c4"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("bb087f75-93e3-4de8-a50b-b79b63ef224a"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("bd2c9dce-7c1a-430e-818a-141dd8fcfc3a"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("c976e399-c219-445c-9bcf-7fbee1b8f53f"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("d1acadc7-2085-433c-8ed7-a58893d26e47"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("d32e8a1b-17ac-46d4-ac5e-306374f752af"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("d49573ed-c32c-4fea-ad99-e737c86204d0"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("d4a1f573-d278-45c5-8811-97b352b294ed"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("db8f1e58-7d66-4d82-a4a0-7ba06e0d5407"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("e16d0d52-0f76-404a-8823-fe6dcf96d272"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("e1b10568-cc3b-4a1f-8bf7-ad5477fbe422"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("e659c85d-9472-41a7-a98f-b505155ba3a8"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("e7ece826-5e40-4175-869d-c85a70ad866f"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("e93dc31b-c9c0-4076-a263-9dfaccdc6c5d"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("ebda3531-5261-48ea-a8bb-46c2166e0e96"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("ec653cb5-3de4-435f-93eb-0b9bfd93a3f7"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("ec6d68f3-5d35-478a-87b3-fc5f667b27f6"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("ed8cc69e-2825-49fb-b9fd-ddb26b3c3ef4"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("ee1330c0-db69-4eb3-ab5f-87be43636018"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("f220cc33-9c71-4d26-ba27-5801a50405ce"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("faedf7e4-5c5b-4205-b503-7eed61d88cc0"));

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("ffa55825-3886-4501-a2e1-79d7c28bf206"));

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: "EX202001");

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: "EX202002");

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: "EX202003");

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: "EX202004");
        }
    }
}
