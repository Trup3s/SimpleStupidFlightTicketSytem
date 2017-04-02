using System;
using System.Collections.Generic;

namespace SSFTS_GUI {
    class Airplane {
        private String age;
        private String type;
        private String code;
        private List<Uri> images;
        private String mode_s;
        private String serialnumber;
        private String type_code;

        public String Age { get => this.age; }
        public String Type { get => this.type; }
        public String Code { get => this.code; }
        public List<Uri> Images { get => this.images; }
        public String Mode_S { get => this.mode_s; }
        public String Serialnumber { get => this.serialnumber; }
        public String TypeCode { get => this.type_code; }

        public Airplane(String age, String type, String code, List<Uri> images, String mode_s, String serialnumber, String type_code) {
            this.age = age;
            this.type = type;
            this.code = code;
            this.images = images;
            this.mode_s = mode_s;
            this.serialnumber = serialnumber;
            this.type_code = type_code;
        }
    }
}
